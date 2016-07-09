using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using SharedControllerHelper.Models;

namespace SharedControllerHelper
{
    public static class EmailHelper
    {
        public static async void SendEmail(this EmailModel email)
        {
            try
            {
                var mail = email.GetMailMessage();
                
                var server = GetMailServer(email);

                await server.SendMailAsync(mail);

                WindowsEventLog.WriteInfoLog($"Notify emails successfully sent to {string.Join(" - ", mail.To)}");
            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in Sending Email: {exp.Message}");
            }
        }


        private static MailMessage GetMailMessage(this EmailModel email)
        {
            // Construct the alternate body as HTML.
            string body = FileManager.ReadResourceFile("Email.html");

            body = body
                ?.Replace("{appName}", email.AppName)
                .Replace("{version}", email.Version)
                .Replace("{message}", email.Message)
                .Replace("{emailDateTime}", email.EmailDateTime.ToLongDateString());

            var mail = new MailMessage
            {
                From = new MailAddress(email.From),
                Subject = $"{email.Subject}  -  {email.EmailDateTime.ToString("F")}",
                Body = body,
                IsBodyHtml = true
            };

            foreach (var to in email.To)
            {
                mail.To.Add(to);
            }

            return mail;
        }

        private static SmtpClient GetMailServer(EmailModel mail)
        {
            var server = new SmtpClient
            {
                Host = mail.EmailHost,
                Port = mail.EmailHostPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail.From, mail.SenderPassword)
            };

            return server;
        }
    }
}

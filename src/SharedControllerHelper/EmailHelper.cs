using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
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

                var server = GetMailServer(email.From, email.SenderPassword);

                await server.SendMailAsync(mail);
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

        private static SmtpClient GetMailServer(string mailServiceAddress, string mailServicePass)
        {
            var server = new SmtpClient
            {
                Host = "mail.shoniz.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailServiceAddress, mailServicePass)
            };

            return server;
        }
    }
}

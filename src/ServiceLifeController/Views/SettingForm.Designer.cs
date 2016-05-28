namespace ServiceLifeController.Views
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.txtTimerInterval = new Windows.Forms.HintTextBox(this.components);
            this.gbBaseInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatusOn = new System.Windows.Forms.ComboBox();
            this.txtNotifyMessageContent = new Windows.Forms.HintTextBox(this.components);
            this.txtNotifyMsgTitle = new Windows.Forms.HintTextBox(this.components);
            this.txtSmsServiceUsername = new Windows.Forms.HintTextBox(this.components);
            this.lblPass = new System.Windows.Forms.Label();
            this.txtSenderEmailPassword = new Windows.Forms.HintTextBox(this.components);
            this.txtSenderEmailAddress = new Windows.Forms.HintTextBox(this.components);
            this.txtSenderMobileNo = new Windows.Forms.HintTextBox(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtReceiverMobiles = new Windows.Forms.HintTextBox(this.components);
            this.txtReceiverEmails = new Windows.Forms.HintTextBox(this.components);
            this.txtSmsServicePassword = new Windows.Forms.HintTextBox(this.components);
            this.txtEmailHost = new Windows.Forms.HintTextBox(this.components);
            this.txtEmailHostPort = new Windows.Forms.HintTextBox(this.components);
            this.gbSms = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEmailSetting = new System.Windows.Forms.GroupBox();
            this.gbBaseInfo.SuspendLayout();
            this.gbSms.SuspendLayout();
            this.gbEmailSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSetting.Location = new System.Drawing.Point(84, 430);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(186, 73);
            this.btnSaveSetting.TabIndex = 2;
            this.btnSaveSetting.Text = "&Save Setting";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // txtTimerInterval
            // 
            this.txtTimerInterval.EnterToTab = false;
            this.txtTimerInterval.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimerInterval.ForeColor = System.Drawing.Color.Gray;
            this.txtTimerInterval.HintValue = "Timer Interval (sec)";
            this.txtTimerInterval.IsNumerical = true;
            this.txtTimerInterval.Location = new System.Drawing.Point(84, 36);
            this.txtTimerInterval.Name = "txtTimerInterval";
            this.txtTimerInterval.Size = new System.Drawing.Size(160, 27);
            this.txtTimerInterval.TabIndex = 3;
            this.txtTimerInterval.Text = "Timer Interval (sec)";
            this.txtTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimerInterval.TextForeColor = System.Drawing.Color.Black;
            this.txtTimerInterval.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.txtTimerInterval, "Timer Interval (ms)");
            this.txtTimerInterval.Value = "";
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbBaseInfo.Controls.Add(this.label2);
            this.gbBaseInfo.Controls.Add(this.cmbStatusOn);
            this.gbBaseInfo.Controls.Add(this.txtNotifyMessageContent);
            this.gbBaseInfo.Controls.Add(this.txtNotifyMsgTitle);
            this.gbBaseInfo.Controls.Add(this.txtTimerInterval);
            this.gbBaseInfo.Location = new System.Drawing.Point(12, 12);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(329, 397);
            this.gbBaseInfo.TabIndex = 4;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "Base Settings";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Notify When Service Status Changed To:";
            // 
            // cmbStatusOn
            // 
            this.cmbStatusOn.FormattingEnabled = true;
            this.cmbStatusOn.Location = new System.Drawing.Point(40, 113);
            this.cmbStatusOn.Name = "cmbStatusOn";
            this.cmbStatusOn.Size = new System.Drawing.Size(253, 24);
            this.cmbStatusOn.TabIndex = 6;
            // 
            // txtNotifyMessageContent
            // 
            this.txtNotifyMessageContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotifyMessageContent.EnterToTab = false;
            this.txtNotifyMessageContent.ForeColor = System.Drawing.Color.Gray;
            this.txtNotifyMessageContent.HintValue = "\r\n\r\n\r\nNotify Message Content\r\n";
            this.txtNotifyMessageContent.Location = new System.Drawing.Point(40, 254);
            this.txtNotifyMessageContent.Multiline = true;
            this.txtNotifyMessageContent.Name = "txtNotifyMessageContent";
            this.txtNotifyMessageContent.Size = new System.Drawing.Size(253, 121);
            this.txtNotifyMessageContent.TabIndex = 5;
            this.txtNotifyMessageContent.Text = "\r\n\r\n\r\nNotify Message Content\r\n";
            this.txtNotifyMessageContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotifyMessageContent.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtNotifyMessageContent, "Notify Message Content");
            this.txtNotifyMessageContent.Value = "";
            // 
            // txtNotifyMsgTitle
            // 
            this.txtNotifyMsgTitle.EnterToTab = false;
            this.txtNotifyMsgTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtNotifyMsgTitle.HintValue = "\r\nNotify Message Title";
            this.txtNotifyMsgTitle.Location = new System.Drawing.Point(40, 197);
            this.txtNotifyMsgTitle.Multiline = true;
            this.txtNotifyMsgTitle.Name = "txtNotifyMsgTitle";
            this.txtNotifyMsgTitle.Size = new System.Drawing.Size(253, 51);
            this.txtNotifyMsgTitle.TabIndex = 4;
            this.txtNotifyMsgTitle.Text = "\r\nNotify Message Title";
            this.txtNotifyMsgTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotifyMsgTitle.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtNotifyMsgTitle, "Notify Message Title");
            this.txtNotifyMsgTitle.Value = "";
            // 
            // txtSmsServiceUsername
            // 
            this.txtSmsServiceUsername.EnterToTab = false;
            this.txtSmsServiceUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmsServiceUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtSmsServiceUsername.HintValue = "SMS Service Username\r\n";
            this.txtSmsServiceUsername.Location = new System.Drawing.Point(40, 65);
            this.txtSmsServiceUsername.Name = "txtSmsServiceUsername";
            this.txtSmsServiceUsername.Size = new System.Drawing.Size(253, 27);
            this.txtSmsServiceUsername.TabIndex = 10;
            this.txtSmsServiceUsername.Text = "SMS Service Username\r\n";
            this.txtSmsServiceUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSmsServiceUsername.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtSmsServiceUsername, "SMS Service Username");
            this.txtSmsServiceUsername.Value = "";
            // 
            // lblPass
            // 
            this.lblPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(8, 76);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(161, 17);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "Sender Email Password:";
            // 
            // txtSenderEmailPassword
            // 
            this.txtSenderEmailPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSenderEmailPassword.EnterToTab = false;
            this.txtSenderEmailPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSenderEmailPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderEmailPassword.HintValue = "1234";
            this.txtSenderEmailPassword.Location = new System.Drawing.Point(178, 70);
            this.txtSenderEmailPassword.Name = "txtSenderEmailPassword";
            this.txtSenderEmailPassword.Size = new System.Drawing.Size(313, 26);
            this.txtSenderEmailPassword.TabIndex = 8;
            this.txtSenderEmailPassword.Text = "1234";
            this.txtSenderEmailPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenderEmailPassword.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtSenderEmailPassword, "Sender Email Password");
            this.txtSenderEmailPassword.UseSystemPasswordChar = true;
            this.txtSenderEmailPassword.Value = "";
            // 
            // txtSenderEmailAddress
            // 
            this.txtSenderEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSenderEmailAddress.EnterToTab = false;
            this.txtSenderEmailAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderEmailAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderEmailAddress.HintValue = "Sender Email Address";
            this.txtSenderEmailAddress.Location = new System.Drawing.Point(11, 36);
            this.txtSenderEmailAddress.Name = "txtSenderEmailAddress";
            this.txtSenderEmailAddress.Size = new System.Drawing.Size(480, 27);
            this.txtSenderEmailAddress.TabIndex = 7;
            this.txtSenderEmailAddress.Text = "Sender Email Address";
            this.txtSenderEmailAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenderEmailAddress.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtSenderEmailAddress, "Sender Email Address");
            this.txtSenderEmailAddress.Value = "";
            // 
            // txtSenderMobileNo
            // 
            this.txtSenderMobileNo.EnterToTab = false;
            this.txtSenderMobileNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderMobileNo.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderMobileNo.HintValue = "SMS Sender Number";
            this.txtSenderMobileNo.IsNumerical = true;
            this.txtSenderMobileNo.Location = new System.Drawing.Point(40, 32);
            this.txtSenderMobileNo.Name = "txtSenderMobileNo";
            this.txtSenderMobileNo.Size = new System.Drawing.Size(253, 27);
            this.txtSenderMobileNo.TabIndex = 6;
            this.txtSenderMobileNo.Text = "SMS Sender Number";
            this.txtSenderMobileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenderMobileNo.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtSenderMobileNo, "SMS Sender Number");
            this.txtSenderMobileNo.Value = "";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 50;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 50;
            this.toolTip.ReshowDelay = 10;
            // 
            // txtReceiverMobiles
            // 
            this.txtReceiverMobiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiverMobiles.EnterToTab = false;
            this.txtReceiverMobiles.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiverMobiles.ForeColor = System.Drawing.Color.Gray;
            this.txtReceiverMobiles.HintValue = "\r\nEnter Receiver Mobiles No\r\nExample:\r\n9149149202, \r\n9149203656, \r\n9176543210,\r\n " +
    "...\r\n\r\n\r\n";
            this.txtReceiverMobiles.Location = new System.Drawing.Point(40, 169);
            this.txtReceiverMobiles.Multiline = true;
            this.txtReceiverMobiles.Name = "txtReceiverMobiles";
            this.txtReceiverMobiles.Size = new System.Drawing.Size(253, 322);
            this.txtReceiverMobiles.TabIndex = 0;
            this.txtReceiverMobiles.Text = "\r\nEnter Receiver Mobiles No\r\nExample:\r\n9149149202, \r\n9149203656, \r\n9176543210,\r\n " +
    "...\r\n\r\n\r\n";
            this.txtReceiverMobiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiverMobiles.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtReceiverMobiles, "Receiver Mobiles No");
            this.txtReceiverMobiles.Value = "";
            // 
            // txtReceiverEmails
            // 
            this.txtReceiverEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiverEmails.EnterToTab = false;
            this.txtReceiverEmails.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiverEmails.ForeColor = System.Drawing.Color.Black;
            this.txtReceiverEmails.HintValue = "\r\n\r\n\r\n\r\n\r\nEnter Receiver Emails\r\nExample:\r\nBehzad.khosravifar@gmail.com, Ahmad.Ag" +
    "hazadeh.a@gmail.com, ...\r\n";
            this.txtReceiverEmails.Location = new System.Drawing.Point(11, 156);
            this.txtReceiverEmails.Multiline = true;
            this.txtReceiverEmails.Name = "txtReceiverEmails";
            this.txtReceiverEmails.Size = new System.Drawing.Size(480, 335);
            this.txtReceiverEmails.TabIndex = 0;
            this.txtReceiverEmails.Text = "\r\nEnter Receiver Emails\r\nExample:\r\nBehzad.khosravifar@gmail.com, Ahmad.Aghazadeh." +
    "a@gmail.com, ...\r\n";
            this.txtReceiverEmails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiverEmails.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtReceiverEmails, "Receiver Emails Address");
            this.txtReceiverEmails.Value = "\r\nEnter Receiver Emails\r\nExample:\r\nBehzad.khosravifar@gmail.com, Ahmad.Aghazadeh." +
    "a@gmail.com, ...\r\n";
            // 
            // txtSmsServicePassword
            // 
            this.txtSmsServicePassword.EnterToTab = false;
            this.txtSmsServicePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSmsServicePassword.ForeColor = System.Drawing.Color.Gray;
            this.txtSmsServicePassword.HintValue = "12345";
            this.txtSmsServicePassword.Location = new System.Drawing.Point(40, 129);
            this.txtSmsServicePassword.Name = "txtSmsServicePassword";
            this.txtSmsServicePassword.Size = new System.Drawing.Size(253, 26);
            this.txtSmsServicePassword.TabIndex = 11;
            this.txtSmsServicePassword.Text = "12345";
            this.txtSmsServicePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSmsServicePassword.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtSmsServicePassword, "Sender Email Password");
            this.txtSmsServicePassword.UseSystemPasswordChar = true;
            this.txtSmsServicePassword.Value = "";
            // 
            // txtEmailHost
            // 
            this.txtEmailHost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmailHost.EnterToTab = false;
            this.txtEmailHost.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailHost.ForeColor = System.Drawing.Color.Gray;
            this.txtEmailHost.HintValue = "Email Host (ex: mail.shoniz.com)";
            this.txtEmailHost.Location = new System.Drawing.Point(11, 113);
            this.txtEmailHost.Name = "txtEmailHost";
            this.txtEmailHost.Size = new System.Drawing.Size(271, 30);
            this.txtEmailHost.TabIndex = 10;
            this.txtEmailHost.Text = "Email Host (ex: mail.shoniz.com)";
            this.txtEmailHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmailHost.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtEmailHost, "Email Host (ex: mail.shoniz.com)");
            this.txtEmailHost.Value = "";
            // 
            // txtEmailHostPort
            // 
            this.txtEmailHostPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmailHostPort.EnterToTab = false;
            this.txtEmailHostPort.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailHostPort.ForeColor = System.Drawing.Color.Gray;
            this.txtEmailHostPort.HintValue = "Email Host Port (ex: 587)";
            this.txtEmailHostPort.IsNumerical = true;
            this.txtEmailHostPort.Location = new System.Drawing.Point(288, 113);
            this.txtEmailHostPort.Name = "txtEmailHostPort";
            this.txtEmailHostPort.Size = new System.Drawing.Size(203, 30);
            this.txtEmailHostPort.TabIndex = 11;
            this.txtEmailHostPort.Text = "Email Host Port (ex: 587)";
            this.txtEmailHostPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmailHostPort.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtEmailHostPort, "Email Host Port");
            this.txtEmailHostPort.Value = "";
            // 
            // gbSms
            // 
            this.gbSms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSms.Controls.Add(this.txtSmsServicePassword);
            this.gbSms.Controls.Add(this.label1);
            this.gbSms.Controls.Add(this.txtReceiverMobiles);
            this.gbSms.Controls.Add(this.txtSenderMobileNo);
            this.gbSms.Controls.Add(this.txtSmsServiceUsername);
            this.gbSms.Location = new System.Drawing.Point(880, 12);
            this.gbSms.Name = "gbSms";
            this.gbSms.Size = new System.Drawing.Size(329, 502);
            this.gbSms.TabIndex = 5;
            this.gbSms.TabStop = false;
            this.gbSms.Text = "SMS Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "SMS Service Pass:";
            // 
            // gbEmailSetting
            // 
            this.gbEmailSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEmailSetting.Controls.Add(this.txtEmailHostPort);
            this.gbEmailSetting.Controls.Add(this.txtEmailHost);
            this.gbEmailSetting.Controls.Add(this.txtSenderEmailPassword);
            this.gbEmailSetting.Controls.Add(this.txtReceiverEmails);
            this.gbEmailSetting.Controls.Add(this.lblPass);
            this.gbEmailSetting.Controls.Add(this.txtSenderEmailAddress);
            this.gbEmailSetting.Location = new System.Drawing.Point(361, 12);
            this.gbEmailSetting.Name = "gbEmailSetting";
            this.gbEmailSetting.Size = new System.Drawing.Size(502, 502);
            this.gbEmailSetting.TabIndex = 6;
            this.gbEmailSetting.TabStop = false;
            this.gbEmailSetting.Text = "Email Setting";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 526);
            this.Controls.Add(this.gbEmailSetting);
            this.Controls.Add(this.gbSms);
            this.Controls.Add(this.gbBaseInfo);
            this.Controls.Add(this.btnSaveSetting);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "SettingForm";
            this.Text = "Settings";
            this.gbBaseInfo.ResumeLayout(false);
            this.gbBaseInfo.PerformLayout();
            this.gbSms.ResumeLayout(false);
            this.gbSms.PerformLayout();
            this.gbEmailSetting.ResumeLayout(false);
            this.gbEmailSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveSetting;
        private Windows.Forms.HintTextBox txtTimerInterval;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox gbBaseInfo;
        private Windows.Forms.HintTextBox txtNotifyMsgTitle;
        private Windows.Forms.HintTextBox txtNotifyMessageContent;
        private Windows.Forms.HintTextBox txtSenderMobileNo;
        private Windows.Forms.HintTextBox txtSenderEmailAddress;
        private Windows.Forms.HintTextBox txtSenderEmailPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.GroupBox gbSms;
        private Windows.Forms.HintTextBox txtReceiverMobiles;
        private System.Windows.Forms.GroupBox gbEmailSetting;
        private Windows.Forms.HintTextBox txtReceiverEmails;
        private Windows.Forms.HintTextBox txtSmsServiceUsername;
        private System.Windows.Forms.Label label1;
        private Windows.Forms.HintTextBox txtSmsServicePassword;
        private Windows.Forms.HintTextBox txtEmailHost;
        private Windows.Forms.HintTextBox txtEmailHostPort;
        private System.Windows.Forms.ComboBox cmbStatusOn;
        private System.Windows.Forms.Label label2;
    }
}
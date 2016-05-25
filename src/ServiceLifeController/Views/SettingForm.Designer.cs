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
            this.lblPass = new System.Windows.Forms.Label();
            this.txtSenderEmailPassword = new Windows.Forms.HintTextBox(this.components);
            this.txtSenderEmailAddress = new Windows.Forms.HintTextBox(this.components);
            this.txtSenderMobileNo = new Windows.Forms.HintTextBox(this.components);
            this.txtNotifyMessageContent = new Windows.Forms.HintTextBox(this.components);
            this.txtNotifyMsgTitle = new Windows.Forms.HintTextBox(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtReceiverMobiles = new Windows.Forms.HintTextBox(this.components);
            this.txtReceiverEmails = new Windows.Forms.HintTextBox(this.components);
            this.gbReceiverMobiles = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBaseInfo.SuspendLayout();
            this.gbReceiverMobiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSetting.Location = new System.Drawing.Point(802, 425);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(174, 66);
            this.btnSaveSetting.TabIndex = 2;
            this.btnSaveSetting.Text = "&Save Setting";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // txtTimerInterval
            // 
            this.txtTimerInterval.EnterToTab = false;
            this.txtTimerInterval.ForeColor = System.Drawing.Color.Gray;
            this.txtTimerInterval.HintValue = "Timer Interval (ms)";
            this.txtTimerInterval.IsNumerical = true;
            this.txtTimerInterval.Location = new System.Drawing.Point(16, 36);
            this.txtTimerInterval.Name = "txtTimerInterval";
            this.txtTimerInterval.Size = new System.Drawing.Size(160, 22);
            this.txtTimerInterval.TabIndex = 3;
            this.txtTimerInterval.Text = "Timer Interval (ms)";
            this.txtTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimerInterval.TextForeColor = System.Drawing.Color.Black;
            this.txtTimerInterval.ThousandsSeparator = true;
            this.toolTip.SetToolTip(this.txtTimerInterval, "Timer Interval (ms)");
            this.txtTimerInterval.Value = "";
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Controls.Add(this.lblPass);
            this.gbBaseInfo.Controls.Add(this.txtSenderEmailPassword);
            this.gbBaseInfo.Controls.Add(this.txtSenderEmailAddress);
            this.gbBaseInfo.Controls.Add(this.txtSenderMobileNo);
            this.gbBaseInfo.Controls.Add(this.txtNotifyMessageContent);
            this.gbBaseInfo.Controls.Add(this.txtNotifyMsgTitle);
            this.gbBaseInfo.Controls.Add(this.txtTimerInterval);
            this.gbBaseInfo.Location = new System.Drawing.Point(12, 12);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(382, 399);
            this.gbBaseInfo.TabIndex = 4;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "Base Settings";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(13, 95);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(81, 17);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "Email Pass:";
            // 
            // txtSenderEmailPassword
            // 
            this.txtSenderEmailPassword.EnterToTab = false;
            this.txtSenderEmailPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderEmailPassword.HintValue = "1234";
            this.txtSenderEmailPassword.Location = new System.Drawing.Point(96, 95);
            this.txtSenderEmailPassword.Name = "txtSenderEmailPassword";
            this.txtSenderEmailPassword.Size = new System.Drawing.Size(266, 22);
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
            this.txtSenderEmailAddress.EnterToTab = false;
            this.txtSenderEmailAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderEmailAddress.HintValue = "Sender Email Address";
            this.txtSenderEmailAddress.Location = new System.Drawing.Point(16, 64);
            this.txtSenderEmailAddress.Name = "txtSenderEmailAddress";
            this.txtSenderEmailAddress.Size = new System.Drawing.Size(346, 22);
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
            this.txtSenderMobileNo.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderMobileNo.HintValue = "Sender Mobile No";
            this.txtSenderMobileNo.Location = new System.Drawing.Point(182, 36);
            this.txtSenderMobileNo.Name = "txtSenderMobileNo";
            this.txtSenderMobileNo.Size = new System.Drawing.Size(180, 22);
            this.txtSenderMobileNo.TabIndex = 6;
            this.txtSenderMobileNo.Text = "Sender Mobile No";
            this.txtSenderMobileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenderMobileNo.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtSenderMobileNo, "Sender Mobile No");
            this.txtSenderMobileNo.Value = "";
            // 
            // txtNotifyMessageContent
            // 
            this.txtNotifyMessageContent.EnterToTab = false;
            this.txtNotifyMessageContent.ForeColor = System.Drawing.Color.Gray;
            this.txtNotifyMessageContent.HintValue = "\r\n\r\n\r\n\r\n\r\nNotify Message Content\r\n";
            this.txtNotifyMessageContent.Location = new System.Drawing.Point(16, 207);
            this.txtNotifyMessageContent.Multiline = true;
            this.txtNotifyMessageContent.Name = "txtNotifyMessageContent";
            this.txtNotifyMessageContent.Size = new System.Drawing.Size(346, 186);
            this.txtNotifyMessageContent.TabIndex = 5;
            this.txtNotifyMessageContent.Text = "\r\n\r\n\r\n\r\n\r\nNotify Message Content\r\n";
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
            this.txtNotifyMsgTitle.Location = new System.Drawing.Point(16, 150);
            this.txtNotifyMsgTitle.Multiline = true;
            this.txtNotifyMsgTitle.Name = "txtNotifyMsgTitle";
            this.txtNotifyMsgTitle.Size = new System.Drawing.Size(346, 51);
            this.txtNotifyMsgTitle.TabIndex = 4;
            this.txtNotifyMsgTitle.Text = "\r\nNotify Message Title";
            this.txtNotifyMsgTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotifyMsgTitle.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtNotifyMsgTitle, "Notify Message Title");
            this.txtNotifyMsgTitle.Value = "";
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
            this.txtReceiverMobiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiverMobiles.EnterToTab = false;
            this.txtReceiverMobiles.ForeColor = System.Drawing.Color.Gray;
            this.txtReceiverMobiles.HintValue = "\r\n\r\n\r\n\r\n\r\nEnter Receiver Mobiles No\r\nExample:\r\n09149149202, 09149203656, 09876543" +
    "210, ...\r\n\r\n\r\n";
            this.txtReceiverMobiles.Location = new System.Drawing.Point(3, 18);
            this.txtReceiverMobiles.Multiline = true;
            this.txtReceiverMobiles.Name = "txtReceiverMobiles";
            this.txtReceiverMobiles.Size = new System.Drawing.Size(259, 378);
            this.txtReceiverMobiles.TabIndex = 0;
            this.txtReceiverMobiles.Text = "\r\n\r\n\r\n\r\n\r\nEnter Receiver Mobiles No\r\nExample:\r\n09149149202, 09149203656, 09876543" +
    "210, ...\r\n\r\n\r\n";
            this.txtReceiverMobiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiverMobiles.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtReceiverMobiles, "Receiver Mobiles No");
            this.txtReceiverMobiles.Value = "";
            // 
            // txtReceiverEmails
            // 
            this.txtReceiverEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiverEmails.EnterToTab = false;
            this.txtReceiverEmails.ForeColor = System.Drawing.Color.Gray;
            this.txtReceiverEmails.HintValue = "\r\n\r\n\r\n\r\n\r\nEnter Receiver Emails\r\nExample:\r\nBehzad.khosravifar@gmail.com, Ahmad.Ag" +
    "hazadeh.a@gmail.com, ...\r\n";
            this.txtReceiverEmails.Location = new System.Drawing.Point(3, 18);
            this.txtReceiverEmails.Multiline = true;
            this.txtReceiverEmails.Name = "txtReceiverEmails";
            this.txtReceiverEmails.Size = new System.Drawing.Size(299, 378);
            this.txtReceiverEmails.TabIndex = 0;
            this.txtReceiverEmails.Text = "\r\n\r\n\r\n\r\n\r\nEnter Receiver Emails\r\nExample:\r\nBehzad.khosravifar@gmail.com, Ahmad.Ag" +
    "hazadeh.a@gmail.com, ...\r\n";
            this.txtReceiverEmails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiverEmails.TextForeColor = System.Drawing.Color.Black;
            this.toolTip.SetToolTip(this.txtReceiverEmails, "Receiver Emails Address");
            this.txtReceiverEmails.Value = "";
            // 
            // gbReceiverMobiles
            // 
            this.gbReceiverMobiles.Controls.Add(this.txtReceiverMobiles);
            this.gbReceiverMobiles.Location = new System.Drawing.Point(400, 12);
            this.gbReceiverMobiles.Name = "gbReceiverMobiles";
            this.gbReceiverMobiles.Size = new System.Drawing.Size(265, 399);
            this.gbReceiverMobiles.TabIndex = 5;
            this.gbReceiverMobiles.TabStop = false;
            this.gbReceiverMobiles.Text = "Receiver Mobiles No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReceiverEmails);
            this.groupBox1.Location = new System.Drawing.Point(671, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 399);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receiver Emails";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 503);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbReceiverMobiles);
            this.Controls.Add(this.gbBaseInfo);
            this.Controls.Add(this.btnSaveSetting);
            this.Name = "SettingForm";
            this.Text = "Settings";
            this.gbBaseInfo.ResumeLayout(false);
            this.gbBaseInfo.PerformLayout();
            this.gbReceiverMobiles.ResumeLayout(false);
            this.gbReceiverMobiles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbReceiverMobiles;
        private Windows.Forms.HintTextBox txtReceiverMobiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.Forms.HintTextBox txtReceiverEmails;
    }
}
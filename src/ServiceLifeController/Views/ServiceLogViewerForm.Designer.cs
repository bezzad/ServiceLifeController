namespace ServiceLifeController.Views
{
    partial class ServiceLogViewerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.grbFilters = new System.Windows.Forms.GroupBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.chkAuditFailure = new System.Windows.Forms.CheckBox();
            this.chkAuditSuccess = new System.Windows.Forms.CheckBox();
            this.chkInformations = new System.Windows.Forms.CheckBox();
            this.chkWarnings = new System.Windows.Forms.CheckBox();
            this.chkErrors = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFetchLogs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.grbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 151);
            this.dgvLogs.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.RowTemplate.Height = 40;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(1111, 526);
            this.dgvLogs.TabIndex = 3;
            this.dgvLogs.VirtualMode = true;
            // 
            // grbFilters
            // 
            this.grbFilters.Controls.Add(this.btnClearLogs);
            this.grbFilters.Controls.Add(this.chkAuditFailure);
            this.grbFilters.Controls.Add(this.chkAuditSuccess);
            this.grbFilters.Controls.Add(this.chkInformations);
            this.grbFilters.Controls.Add(this.chkWarnings);
            this.grbFilters.Controls.Add(this.chkErrors);
            this.grbFilters.Controls.Add(this.dtpTo);
            this.grbFilters.Controls.Add(this.label2);
            this.grbFilters.Controls.Add(this.btnFetchLogs);
            this.grbFilters.Controls.Add(this.label1);
            this.grbFilters.Controls.Add(this.dtpFrom);
            this.grbFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFilters.Font = new System.Drawing.Font("Californian FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFilters.Location = new System.Drawing.Point(0, 0);
            this.grbFilters.Margin = new System.Windows.Forms.Padding(4);
            this.grbFilters.Name = "grbFilters";
            this.grbFilters.Padding = new System.Windows.Forms.Padding(4);
            this.grbFilters.Size = new System.Drawing.Size(1111, 151);
            this.grbFilters.TabIndex = 2;
            this.grbFilters.TabStop = false;
            this.grbFilters.Text = "Log Filters";
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLogs.Font = new System.Drawing.Font("Californian FB", 14.25F);
            this.btnClearLogs.Location = new System.Drawing.Point(801, 37);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(143, 82);
            this.btnClearLogs.TabIndex = 10;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // chkAuditFailure
            // 
            this.chkAuditFailure.AutoSize = true;
            this.chkAuditFailure.Checked = true;
            this.chkAuditFailure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuditFailure.Location = new System.Drawing.Point(539, 98);
            this.chkAuditFailure.Margin = new System.Windows.Forms.Padding(4);
            this.chkAuditFailure.Name = "chkAuditFailure";
            this.chkAuditFailure.Size = new System.Drawing.Size(135, 26);
            this.chkAuditFailure.TabIndex = 9;
            this.chkAuditFailure.Text = "Audit Failure";
            this.chkAuditFailure.UseVisualStyleBackColor = true;
            // 
            // chkAuditSuccess
            // 
            this.chkAuditSuccess.AutoSize = true;
            this.chkAuditSuccess.Checked = true;
            this.chkAuditSuccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuditSuccess.Location = new System.Drawing.Point(384, 98);
            this.chkAuditSuccess.Margin = new System.Windows.Forms.Padding(4);
            this.chkAuditSuccess.Name = "chkAuditSuccess";
            this.chkAuditSuccess.Size = new System.Drawing.Size(141, 26);
            this.chkAuditSuccess.TabIndex = 8;
            this.chkAuditSuccess.Text = "Audit Success";
            this.chkAuditSuccess.UseVisualStyleBackColor = true;
            // 
            // chkInformations
            // 
            this.chkInformations.AutoSize = true;
            this.chkInformations.Checked = true;
            this.chkInformations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInformations.Location = new System.Drawing.Point(237, 98);
            this.chkInformations.Margin = new System.Windows.Forms.Padding(4);
            this.chkInformations.Name = "chkInformations";
            this.chkInformations.Size = new System.Drawing.Size(130, 26);
            this.chkInformations.TabIndex = 7;
            this.chkInformations.Text = "Informations";
            this.chkInformations.UseVisualStyleBackColor = true;
            // 
            // chkWarnings
            // 
            this.chkWarnings.AutoSize = true;
            this.chkWarnings.Checked = true;
            this.chkWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWarnings.Location = new System.Drawing.Point(115, 98);
            this.chkWarnings.Margin = new System.Windows.Forms.Padding(4);
            this.chkWarnings.Name = "chkWarnings";
            this.chkWarnings.Size = new System.Drawing.Size(109, 26);
            this.chkWarnings.TabIndex = 6;
            this.chkWarnings.Text = "Warnings";
            this.chkWarnings.UseVisualStyleBackColor = true;
            // 
            // chkErrors
            // 
            this.chkErrors.AutoSize = true;
            this.chkErrors.Checked = true;
            this.chkErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkErrors.Location = new System.Drawing.Point(20, 98);
            this.chkErrors.Margin = new System.Windows.Forms.Padding(4);
            this.chkErrors.Name = "chkErrors";
            this.chkErrors.Size = new System.Drawing.Size(81, 26);
            this.chkErrors.TabIndex = 5;
            this.chkErrors.Text = "Errors";
            this.chkErrors.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Checked = false;
            this.dtpTo.CustomFormat = "";
            this.dtpTo.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(453, 36);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTo.MaxDate = new System.DateTime(2300, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(157, 26);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date:";
            // 
            // btnFetchLogs
            // 
            this.btnFetchLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFetchLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFetchLogs.Font = new System.Drawing.Font("Californian FB", 14.25F);
            this.btnFetchLogs.Location = new System.Drawing.Point(952, 37);
            this.btnFetchLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnFetchLogs.Name = "btnFetchLogs";
            this.btnFetchLogs.Size = new System.Drawing.Size(143, 82);
            this.btnFetchLogs.TabIndex = 2;
            this.btnFetchLogs.Text = "Fetch Logs";
            this.btnFetchLogs.UseVisualStyleBackColor = true;
            this.btnFetchLogs.Click += new System.EventHandler(this.btnFetchLogs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = false;
            this.dtpFrom.CustomFormat = "";
            this.dtpFrom.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(121, 36);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFrom.MaxDate = new System.DateTime(2300, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(157, 26);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // ServiceLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 677);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.grbFilters);
            this.Name = "ServiceLogViewer";
            this.Text = "Service Log Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.grbFilters.ResumeLayout(false);
            this.grbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.GroupBox grbFilters;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.CheckBox chkAuditFailure;
        private System.Windows.Forms.CheckBox chkAuditSuccess;
        private System.Windows.Forms.CheckBox chkInformations;
        private System.Windows.Forms.CheckBox chkWarnings;
        private System.Windows.Forms.CheckBox chkErrors;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFetchLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}
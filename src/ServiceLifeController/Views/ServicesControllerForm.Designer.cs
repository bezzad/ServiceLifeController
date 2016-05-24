namespace ServiceLifeController.Views
{
    partial class ServicesControllerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.gbAllServices = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.gbSelectedServices = new System.Windows.Forms.GroupBox();
            this.lstSelectedServices = new System.Windows.Forms.ListBox();
            this.btnShowEventLogs = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.gbAllServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbTools.SuspendLayout();
            this.gbSelectedServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.Location = new System.Drawing.Point(3, 18);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.RowTemplate.Height = 24;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(742, 700);
            this.dgvServices.TabIndex = 0;
            // 
            // gbAllServices
            // 
            this.gbAllServices.Controls.Add(this.dgvServices);
            this.gbAllServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAllServices.Location = new System.Drawing.Point(0, 0);
            this.gbAllServices.Name = "gbAllServices";
            this.gbAllServices.Size = new System.Drawing.Size(748, 721);
            this.gbAllServices.TabIndex = 1;
            this.gbAllServices.TabStop = false;
            this.gbAllServices.Text = "Services";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbAllServices);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbTools);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Size = new System.Drawing.Size(1312, 721);
            this.splitContainer1.SplitterDistance = 748;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 2;
            // 
            // gbTools
            // 
            this.gbTools.Controls.Add(this.gbSelectedServices);
            this.gbTools.Controls.Add(this.btnShowEventLogs);
            this.gbTools.Controls.Add(this.btnSaveSetting);
            this.gbTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTools.Location = new System.Drawing.Point(3, 0);
            this.gbTools.Name = "gbTools";
            this.gbTools.Size = new System.Drawing.Size(551, 721);
            this.gbTools.TabIndex = 2;
            this.gbTools.TabStop = false;
            this.gbTools.Text = "Tools";
            // 
            // gbSelectedServices
            // 
            this.gbSelectedServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectedServices.Controls.Add(this.lstSelectedServices);
            this.gbSelectedServices.Location = new System.Drawing.Point(6, 29);
            this.gbSelectedServices.Name = "gbSelectedServices";
            this.gbSelectedServices.Size = new System.Drawing.Size(533, 608);
            this.gbSelectedServices.TabIndex = 3;
            this.gbSelectedServices.TabStop = false;
            this.gbSelectedServices.Text = "Selected Services";
            // 
            // lstSelectedServices
            // 
            this.lstSelectedServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectedServices.FormattingEnabled = true;
            this.lstSelectedServices.ItemHeight = 16;
            this.lstSelectedServices.Location = new System.Drawing.Point(3, 18);
            this.lstSelectedServices.Name = "lstSelectedServices";
            this.lstSelectedServices.Size = new System.Drawing.Size(527, 587);
            this.lstSelectedServices.TabIndex = 0;
            // 
            // btnShowEventLogs
            // 
            this.btnShowEventLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowEventLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnShowEventLogs.Location = new System.Drawing.Point(182, 643);
            this.btnShowEventLogs.Name = "btnShowEventLogs";
            this.btnShowEventLogs.Size = new System.Drawing.Size(174, 66);
            this.btnShowEventLogs.TabIndex = 2;
            this.btnShowEventLogs.Text = "Show &Event Logs";
            this.btnShowEventLogs.UseVisualStyleBackColor = true;
            this.btnShowEventLogs.Click += new System.EventHandler(this.btnShowEventLogs_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSaveSetting.Location = new System.Drawing.Point(362, 643);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(174, 66);
            this.btnSaveSetting.TabIndex = 1;
            this.btnSaveSetting.Text = "&Setting";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 721);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // ServicesControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 721);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ServicesControllerForm";
            this.Text = "Services Controller";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.gbAllServices.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbTools.ResumeLayout(false);
            this.gbSelectedServices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.GroupBox gbAllServices;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.ListBox lstSelectedServices;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Button btnShowEventLogs;
        private System.Windows.Forms.GroupBox gbSelectedServices;
    }
}


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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.gbAllServices = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.gbSelectedServices = new System.Windows.Forms.GroupBox();
            this.dgvSelectedServices = new System.Windows.Forms.DataGridView();
            this.ColServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKeepServiceStatusOn = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServices.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvServices.ColumnHeadersHeight = 30;
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.Location = new System.Drawing.Point(3, 18);
            this.dgvServices.MultiSelect = false;
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
            this.gbSelectedServices.Controls.Add(this.dgvSelectedServices);
            this.gbSelectedServices.Location = new System.Drawing.Point(6, 29);
            this.gbSelectedServices.Name = "gbSelectedServices";
            this.gbSelectedServices.Size = new System.Drawing.Size(533, 608);
            this.gbSelectedServices.TabIndex = 3;
            this.gbSelectedServices.TabStop = false;
            this.gbSelectedServices.Text = "Selected Services";
            // 
            // dgvSelectedServices
            // 
            this.dgvSelectedServices.AllowUserToAddRows = false;
            this.dgvSelectedServices.AllowUserToDeleteRows = false;
            this.dgvSelectedServices.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSelectedServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectedServices.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelectedServices.ColumnHeadersHeight = 30;
            this.dgvSelectedServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServiceName,
            this.ColKeepServiceStatusOn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectedServices.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSelectedServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectedServices.Location = new System.Drawing.Point(3, 18);
            this.dgvSelectedServices.Name = "dgvSelectedServices";
            this.dgvSelectedServices.RowHeadersVisible = false;
            this.dgvSelectedServices.RowTemplate.Height = 24;
            this.dgvSelectedServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedServices.Size = new System.Drawing.Size(527, 587);
            this.dgvSelectedServices.TabIndex = 0;
            // 
            // ColServiceName
            // 
            this.ColServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColServiceName.HeaderText = "Service Name";
            this.ColServiceName.MinimumWidth = 100;
            this.ColServiceName.Name = "ColServiceName";
            this.ColServiceName.ReadOnly = true;
            // 
            // ColKeepServiceStatusOn
            // 
            this.ColKeepServiceStatusOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColKeepServiceStatusOn.HeaderText = "Keep Service Status On";
            this.ColKeepServiceStatusOn.MinimumWidth = 100;
            this.ColKeepServiceStatusOn.Name = "ColKeepServiceStatusOn";
            this.ColKeepServiceStatusOn.Width = 167;
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
            this.Text = "Services Controller  (Run as Admin)  (Run as Admin)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.gbAllServices.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbTools.ResumeLayout(false);
            this.gbSelectedServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.GroupBox gbAllServices;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Button btnShowEventLogs;
        private System.Windows.Forms.GroupBox gbSelectedServices;
        private System.Windows.Forms.DataGridView dgvSelectedServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColKeepServiceStatusOn;
    }
}


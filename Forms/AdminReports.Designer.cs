namespace e_Shift.Forms
{
    partial class AdminReports
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
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.btnDownloadCSV = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblReportType = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.GridColor = System.Drawing.Color.White;
            this.dataGridViewReports.Location = new System.Drawing.Point(7, 95);
            this.dataGridViewReports.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.RowHeadersWidth = 51;
            this.dataGridViewReports.Size = new System.Drawing.Size(746, 373);
            this.dataGridViewReports.TabIndex = 90;
            // 
            // btnDownloadCSV
            // 
            this.btnDownloadCSV.BackColor = System.Drawing.Color.DeepPink;
            this.btnDownloadCSV.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadCSV.ForeColor = System.Drawing.Color.White;
            this.btnDownloadCSV.Location = new System.Drawing.Point(536, 474);
            this.btnDownloadCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDownloadCSV.Name = "btnDownloadCSV";
            this.btnDownloadCSV.Size = new System.Drawing.Size(217, 55);
            this.btnDownloadCSV.TabIndex = 91;
            this.btnDownloadCSV.Text = "Download CSV";
            this.btnDownloadCSV.UseVisualStyleBackColor = false;
            this.btnDownloadCSV.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.DeepPink;
            this.btnGenerate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(394, 29);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(134, 40);
            this.btnGenerate.TabIndex = 93;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.BackColor = System.Drawing.Color.Transparent;
            this.lblReportType.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.ForeColor = System.Drawing.Color.Black;
            this.lblReportType.Location = new System.Drawing.Point(12, 35);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(127, 28);
            this.lblReportType.TabIndex = 94;
            this.lblReportType.Text = "Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(152, 38);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(224, 24);
            this.cmbReportType.TabIndex = 95;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // AdminReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(760, 569);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnDownloadCSV);
            this.Controls.Add(this.dataGridViewReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminReports";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Button btnDownloadCSV;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cmbReportType;
    }
}
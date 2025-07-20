namespace e_Shift.Forms
{
    partial class AdminLoadManagement
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
            this.txtLoadID = new MetroFramework.Controls.MetroTextBox();
            this.lblLoadId = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewLoads = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtWeight = new MetroFramework.Controls.MetroTextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblLoadNumber = new System.Windows.Forms.Label();
            this.txtLoadNumber = new MetroFramework.Controls.MetroTextBox();
            this.txtNumberOfLoads = new MetroFramework.Controls.MetroTextBox();
            this.lblNumberOfLoads = new System.Windows.Forms.Label();
            this.lblProductListID = new System.Windows.Forms.Label();
            this.cmbProductListID = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbJobID = new System.Windows.Forms.ComboBox();
            this.lblJobID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoads)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoadID
            // 
            // 
            // 
            // 
            this.txtLoadID.CustomButton.Image = null;
            this.txtLoadID.CustomButton.Location = new System.Drawing.Point(407, 2);
            this.txtLoadID.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoadID.CustomButton.Name = "";
            this.txtLoadID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLoadID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLoadID.CustomButton.TabIndex = 1;
            this.txtLoadID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLoadID.CustomButton.UseSelectable = true;
            this.txtLoadID.CustomButton.Visible = false;
            this.txtLoadID.Lines = new string[0];
            this.txtLoadID.Location = new System.Drawing.Point(264, 30);
            this.txtLoadID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoadID.MaxLength = 32767;
            this.txtLoadID.Name = "txtLoadID";
            this.txtLoadID.PasswordChar = '\0';
            this.txtLoadID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLoadID.SelectedText = "";
            this.txtLoadID.SelectionLength = 0;
            this.txtLoadID.SelectionStart = 0;
            this.txtLoadID.ShortcutsEnabled = true;
            this.txtLoadID.Size = new System.Drawing.Size(435, 30);
            this.txtLoadID.TabIndex = 80;
            this.txtLoadID.UseSelectable = true;
            this.txtLoadID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLoadID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblLoadId
            // 
            this.lblLoadId.AutoSize = true;
            this.lblLoadId.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadId.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadId.ForeColor = System.Drawing.Color.Black;
            this.lblLoadId.Location = new System.Drawing.Point(62, 30);
            this.lblLoadId.Name = "lblLoadId";
            this.lblLoadId.Size = new System.Drawing.Size(83, 28);
            this.lblLoadId.TabIndex = 79;
            this.lblLoadId.Text = "Load ID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepPink;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(528, 327);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 55);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewLoads
            // 
            this.dataGridViewLoads.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoads.GridColor = System.Drawing.Color.White;
            this.dataGridViewLoads.Location = new System.Drawing.Point(61, 404);
            this.dataGridViewLoads.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewLoads.Name = "dataGridViewLoads";
            this.dataGridViewLoads.RowHeadersWidth = 51;
            this.dataGridViewLoads.Size = new System.Drawing.Size(637, 152);
            this.dataGridViewLoads.TabIndex = 77;
            this.dataGridViewLoads.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLoads_CellContentDoubleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DeepPink;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(352, 327);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(171, 55);
            this.btnUpdate.TabIndex = 76;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepPink;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(176, 327);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(171, 55);
            this.btnAdd.TabIndex = 74;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtWeight
            // 
            // 
            // 
            // 
            this.txtWeight.CustomButton.Image = null;
            this.txtWeight.CustomButton.Location = new System.Drawing.Point(407, 2);
            this.txtWeight.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWeight.CustomButton.Name = "";
            this.txtWeight.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtWeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtWeight.CustomButton.TabIndex = 1;
            this.txtWeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtWeight.CustomButton.UseSelectable = true;
            this.txtWeight.CustomButton.Visible = false;
            this.txtWeight.Lines = new string[0];
            this.txtWeight.Location = new System.Drawing.Point(263, 242);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWeight.MaxLength = 32767;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PasswordChar = '\0';
            this.txtWeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtWeight.SelectedText = "";
            this.txtWeight.SelectionLength = 0;
            this.txtWeight.SelectionStart = 0;
            this.txtWeight.ShortcutsEnabled = true;
            this.txtWeight.Size = new System.Drawing.Size(435, 30);
            this.txtWeight.TabIndex = 72;
            this.txtWeight.UseSelectable = true;
            this.txtWeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtWeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.BackColor = System.Drawing.Color.Transparent;
            this.lblWeight.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.ForeColor = System.Drawing.Color.Black;
            this.lblWeight.Location = new System.Drawing.Point(62, 242);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(81, 28);
            this.lblWeight.TabIndex = 69;
            this.lblWeight.Text = "Weight";
            // 
            // lblLoadNumber
            // 
            this.lblLoadNumber.AutoSize = true;
            this.lblLoadNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadNumber.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadNumber.ForeColor = System.Drawing.Color.Black;
            this.lblLoadNumber.Location = new System.Drawing.Point(62, 151);
            this.lblLoadNumber.Name = "lblLoadNumber";
            this.lblLoadNumber.Size = new System.Drawing.Size(140, 28);
            this.lblLoadNumber.TabIndex = 68;
            this.lblLoadNumber.Text = "Load Number";
            // 
            // txtLoadNumber
            // 
            // 
            // 
            // 
            this.txtLoadNumber.CustomButton.Image = null;
            this.txtLoadNumber.CustomButton.Location = new System.Drawing.Point(407, 2);
            this.txtLoadNumber.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoadNumber.CustomButton.Name = "";
            this.txtLoadNumber.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLoadNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLoadNumber.CustomButton.TabIndex = 1;
            this.txtLoadNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLoadNumber.CustomButton.UseSelectable = true;
            this.txtLoadNumber.CustomButton.Visible = false;
            this.txtLoadNumber.Lines = new string[0];
            this.txtLoadNumber.Location = new System.Drawing.Point(263, 151);
            this.txtLoadNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoadNumber.MaxLength = 32767;
            this.txtLoadNumber.Name = "txtLoadNumber";
            this.txtLoadNumber.PasswordChar = '\0';
            this.txtLoadNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLoadNumber.SelectedText = "";
            this.txtLoadNumber.SelectionLength = 0;
            this.txtLoadNumber.SelectionStart = 0;
            this.txtLoadNumber.ShortcutsEnabled = true;
            this.txtLoadNumber.Size = new System.Drawing.Size(435, 30);
            this.txtLoadNumber.TabIndex = 81;
            this.txtLoadNumber.UseSelectable = true;
            this.txtLoadNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLoadNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtNumberOfLoads
            // 
            // 
            // 
            // 
            this.txtNumberOfLoads.CustomButton.Image = null;
            this.txtNumberOfLoads.CustomButton.Location = new System.Drawing.Point(407, 2);
            this.txtNumberOfLoads.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumberOfLoads.CustomButton.Name = "";
            this.txtNumberOfLoads.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtNumberOfLoads.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNumberOfLoads.CustomButton.TabIndex = 1;
            this.txtNumberOfLoads.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNumberOfLoads.CustomButton.UseSelectable = true;
            this.txtNumberOfLoads.CustomButton.Visible = false;
            this.txtNumberOfLoads.Lines = new string[0];
            this.txtNumberOfLoads.Location = new System.Drawing.Point(264, 195);
            this.txtNumberOfLoads.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumberOfLoads.MaxLength = 32767;
            this.txtNumberOfLoads.Name = "txtNumberOfLoads";
            this.txtNumberOfLoads.PasswordChar = '\0';
            this.txtNumberOfLoads.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNumberOfLoads.SelectedText = "";
            this.txtNumberOfLoads.SelectionLength = 0;
            this.txtNumberOfLoads.SelectionStart = 0;
            this.txtNumberOfLoads.ShortcutsEnabled = true;
            this.txtNumberOfLoads.Size = new System.Drawing.Size(435, 30);
            this.txtNumberOfLoads.TabIndex = 83;
            this.txtNumberOfLoads.UseSelectable = true;
            this.txtNumberOfLoads.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNumberOfLoads.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNumberOfLoads
            // 
            this.lblNumberOfLoads.AutoSize = true;
            this.lblNumberOfLoads.BackColor = System.Drawing.Color.Transparent;
            this.lblNumberOfLoads.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfLoads.ForeColor = System.Drawing.Color.Black;
            this.lblNumberOfLoads.Location = new System.Drawing.Point(62, 195);
            this.lblNumberOfLoads.Name = "lblNumberOfLoads";
            this.lblNumberOfLoads.Size = new System.Drawing.Size(173, 28);
            this.lblNumberOfLoads.TabIndex = 82;
            this.lblNumberOfLoads.Text = "Number of Loads";
            // 
            // lblProductListID
            // 
            this.lblProductListID.AutoSize = true;
            this.lblProductListID.BackColor = System.Drawing.Color.Transparent;
            this.lblProductListID.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductListID.ForeColor = System.Drawing.Color.Black;
            this.lblProductListID.Location = new System.Drawing.Point(61, 76);
            this.lblProductListID.Name = "lblProductListID";
            this.lblProductListID.Size = new System.Drawing.Size(159, 28);
            this.lblProductListID.TabIndex = 84;
            this.lblProductListID.Text = "Products List ID";
            // 
            // cmbProductListID
            // 
            this.cmbProductListID.FormattingEnabled = true;
            this.cmbProductListID.Location = new System.Drawing.Point(263, 79);
            this.cmbProductListID.Name = "cmbProductListID";
            this.cmbProductListID.Size = new System.Drawing.Size(436, 24);
            this.cmbProductListID.TabIndex = 85;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(62, 288);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 28);
            this.lblStatus.TabIndex = 70;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(262, 292);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(436, 24);
            this.cmbStatus.TabIndex = 86;
            // 
            // cmbJobID
            // 
            this.cmbJobID.FormattingEnabled = true;
            this.cmbJobID.Location = new System.Drawing.Point(264, 115);
            this.cmbJobID.Name = "cmbJobID";
            this.cmbJobID.Size = new System.Drawing.Size(436, 24);
            this.cmbJobID.TabIndex = 88;
            // 
            // lblJobID
            // 
            this.lblJobID.AutoSize = true;
            this.lblJobID.BackColor = System.Drawing.Color.Transparent;
            this.lblJobID.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobID.ForeColor = System.Drawing.Color.Black;
            this.lblJobID.Location = new System.Drawing.Point(62, 112);
            this.lblJobID.Name = "lblJobID";
            this.lblJobID.Size = new System.Drawing.Size(70, 28);
            this.lblJobID.TabIndex = 87;
            this.lblJobID.Text = "Job ID";
            // 
            // AdminLoadManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(760, 569);
            this.Controls.Add(this.cmbJobID);
            this.Controls.Add(this.lblJobID);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbProductListID);
            this.Controls.Add(this.lblProductListID);
            this.Controls.Add(this.txtNumberOfLoads);
            this.Controls.Add(this.lblNumberOfLoads);
            this.Controls.Add(this.txtLoadNumber);
            this.Controls.Add(this.txtLoadID);
            this.Controls.Add(this.lblLoadId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewLoads);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblLoadNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLoadManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminLoadManagement";
            this.Load += new System.EventHandler(this.AdminLoadManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtLoadID;
        private System.Windows.Forms.Label lblLoadId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewLoads;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private MetroFramework.Controls.MetroTextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblLoadNumber;
        private MetroFramework.Controls.MetroTextBox txtLoadNumber;
        private MetroFramework.Controls.MetroTextBox txtNumberOfLoads;
        private System.Windows.Forms.Label lblNumberOfLoads;
        private System.Windows.Forms.Label lblProductListID;
        private System.Windows.Forms.ComboBox cmbProductListID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbJobID;
        private System.Windows.Forms.Label lblJobID;
    }
}
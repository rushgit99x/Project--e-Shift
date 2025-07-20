namespace e_Shift.Forms.TransportUnits
{
    partial class Drivers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drivers));
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtDriverId = new MetroFramework.Controls.MetroTextBox();
            this.lblDriverID = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewDrivers = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.txtFirstName = new MetroFramework.Controls.MetroTextBox();
            this.lblLicenseNo = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblDriverTitle = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBoxDriver = new System.Windows.Forms.PictureBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtLicenseNo = new MetroFramework.Controls.MetroTextBox();
            this.txtPhone = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDriver)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(185, 385);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(246, 24);
            this.cmbStatus.TabIndex = 100;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(42, 385);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 28);
            this.lblStatus.TabIndex = 99;
            this.lblStatus.Text = "Status";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DeepPink;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(248, 503);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(171, 55);
            this.btnBack.TabIndex = 98;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtDriverId
            // 
            // 
            // 
            // 
            this.txtDriverId.CustomButton.Image = null;
            this.txtDriverId.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtDriverId.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDriverId.CustomButton.Name = "";
            this.txtDriverId.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtDriverId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDriverId.CustomButton.TabIndex = 1;
            this.txtDriverId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDriverId.CustomButton.UseSelectable = true;
            this.txtDriverId.CustomButton.Visible = false;
            this.txtDriverId.Lines = new string[0];
            this.txtDriverId.Location = new System.Drawing.Point(185, 104);
            this.txtDriverId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDriverId.MaxLength = 32767;
            this.txtDriverId.Name = "txtDriverId";
            this.txtDriverId.PasswordChar = '\0';
            this.txtDriverId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDriverId.SelectedText = "";
            this.txtDriverId.SelectionLength = 0;
            this.txtDriverId.SelectionStart = 0;
            this.txtDriverId.ShortcutsEnabled = true;
            this.txtDriverId.Size = new System.Drawing.Size(246, 30);
            this.txtDriverId.TabIndex = 97;
            this.txtDriverId.UseSelectable = true;
            this.txtDriverId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDriverId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblDriverID
            // 
            this.lblDriverID.AutoSize = true;
            this.lblDriverID.BackColor = System.Drawing.Color.White;
            this.lblDriverID.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverID.Location = new System.Drawing.Point(42, 106);
            this.lblDriverID.Name = "lblDriverID";
            this.lblDriverID.Size = new System.Drawing.Size(98, 28);
            this.lblDriverID.TabIndex = 96;
            this.lblDriverID.Text = "Driver ID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepPink;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(47, 503);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 55);
            this.btnDelete.TabIndex = 95;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewDrivers
            // 
            this.dataGridViewDrivers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrivers.GridColor = System.Drawing.Color.White;
            this.dataGridViewDrivers.Location = new System.Drawing.Point(469, 95);
            this.dataGridViewDrivers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewDrivers.Name = "dataGridViewDrivers";
            this.dataGridViewDrivers.RowHeadersWidth = 51;
            this.dataGridViewDrivers.Size = new System.Drawing.Size(518, 577);
            this.dataGridViewDrivers.TabIndex = 94;
            this.dataGridViewDrivers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDrivers_CellContentClick);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DeepPink;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(248, 444);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(171, 55);
            this.btnEdit.TabIndex = 93;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Snow;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnMinimize.Location = new System.Drawing.Point(919, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 29;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DeepPink;
            this.btnRegister.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(47, 444);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(171, 55);
            this.btnRegister.TabIndex = 92;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtLastName
            // 
            // 
            // 
            // 
            this.txtLastName.CustomButton.Image = null;
            this.txtLastName.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtLastName.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.CustomButton.Name = "";
            this.txtLastName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLastName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLastName.CustomButton.TabIndex = 1;
            this.txtLastName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLastName.CustomButton.UseSelectable = true;
            this.txtLastName.CustomButton.Visible = false;
            this.txtLastName.Lines = new string[0];
            this.txtLastName.Location = new System.Drawing.Point(185, 223);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.MaxLength = 32767;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PasswordChar = '\0';
            this.txtLastName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLastName.SelectedText = "";
            this.txtLastName.SelectionLength = 0;
            this.txtLastName.SelectionStart = 0;
            this.txtLastName.ShortcutsEnabled = true;
            this.txtLastName.Size = new System.Drawing.Size(246, 30);
            this.txtLastName.TabIndex = 91;
            this.txtLastName.UseSelectable = true;
            this.txtLastName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLastName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtFirstName
            // 
            // 
            // 
            // 
            this.txtFirstName.CustomButton.Image = null;
            this.txtFirstName.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtFirstName.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.CustomButton.Name = "";
            this.txtFirstName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtFirstName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFirstName.CustomButton.TabIndex = 1;
            this.txtFirstName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFirstName.CustomButton.UseSelectable = true;
            this.txtFirstName.CustomButton.Visible = false;
            this.txtFirstName.Lines = new string[0];
            this.txtFirstName.Location = new System.Drawing.Point(185, 161);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.MaxLength = 32767;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PasswordChar = '\0';
            this.txtFirstName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.SelectionLength = 0;
            this.txtFirstName.SelectionStart = 0;
            this.txtFirstName.ShortcutsEnabled = true;
            this.txtFirstName.Size = new System.Drawing.Size(246, 30);
            this.txtFirstName.TabIndex = 90;
            this.txtFirstName.UseSelectable = true;
            this.txtFirstName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFirstName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblLicenseNo
            // 
            this.lblLicenseNo.AutoSize = true;
            this.lblLicenseNo.BackColor = System.Drawing.Color.White;
            this.lblLicenseNo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseNo.Location = new System.Drawing.Point(42, 285);
            this.lblLicenseNo.Name = "lblLicenseNo";
            this.lblLicenseNo.Size = new System.Drawing.Size(115, 28);
            this.lblLicenseNo.TabIndex = 89;
            this.lblLicenseNo.Text = "License No";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.White;
            this.lblLastName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(42, 224);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(112, 28);
            this.lblLastName.TabIndex = 88;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.White;
            this.lblFirstName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(42, 161);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(116, 28);
            this.lblFirstName.TabIndex = 87;
            this.lblFirstName.Text = "First Name";
            // 
            // lblDriverTitle
            // 
            this.lblDriverTitle.AutoSize = true;
            this.lblDriverTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverTitle.Location = new System.Drawing.Point(21, 11);
            this.lblDriverTitle.Name = "lblDriverTitle";
            this.lblDriverTitle.Size = new System.Drawing.Size(177, 24);
            this.lblDriverTitle.TabIndex = 30;
            this.lblDriverTitle.Text = "Driver Management";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblDriverTitle);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1001, 44);
            this.panelTitle.TabIndex = 86;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Snow;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClose.Location = new System.Drawing.Point(960, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBoxDriver
            // 
            this.pictureBoxDriver.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDriver.Image")));
            this.pictureBoxDriver.Location = new System.Drawing.Point(-1, 0);
            this.pictureBoxDriver.Name = "pictureBoxDriver";
            this.pictureBoxDriver.Size = new System.Drawing.Size(1001, 705);
            this.pictureBoxDriver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDriver.TabIndex = 85;
            this.pictureBoxDriver.TabStop = false;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.White;
            this.lblPhone.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(42, 335);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(72, 28);
            this.lblPhone.TabIndex = 102;
            this.lblPhone.Text = "Phone";
            // 
            // txtLicenseNo
            // 
            // 
            // 
            // 
            this.txtLicenseNo.CustomButton.Image = null;
            this.txtLicenseNo.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtLicenseNo.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLicenseNo.CustomButton.Name = "";
            this.txtLicenseNo.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLicenseNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLicenseNo.CustomButton.TabIndex = 1;
            this.txtLicenseNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLicenseNo.CustomButton.UseSelectable = true;
            this.txtLicenseNo.CustomButton.Visible = false;
            this.txtLicenseNo.Lines = new string[0];
            this.txtLicenseNo.Location = new System.Drawing.Point(185, 285);
            this.txtLicenseNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLicenseNo.MaxLength = 32767;
            this.txtLicenseNo.Name = "txtLicenseNo";
            this.txtLicenseNo.PasswordChar = '\0';
            this.txtLicenseNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLicenseNo.SelectedText = "";
            this.txtLicenseNo.SelectionLength = 0;
            this.txtLicenseNo.SelectionStart = 0;
            this.txtLicenseNo.ShortcutsEnabled = true;
            this.txtLicenseNo.Size = new System.Drawing.Size(246, 30);
            this.txtLicenseNo.TabIndex = 104;
            this.txtLicenseNo.UseSelectable = true;
            this.txtLicenseNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLicenseNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPhone
            // 
            // 
            // 
            // 
            this.txtPhone.CustomButton.Image = null;
            this.txtPhone.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtPhone.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.CustomButton.Name = "";
            this.txtPhone.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPhone.CustomButton.TabIndex = 1;
            this.txtPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPhone.CustomButton.UseSelectable = true;
            this.txtPhone.CustomButton.Visible = false;
            this.txtPhone.Lines = new string[0];
            this.txtPhone.Location = new System.Drawing.Point(185, 335);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.MaxLength = 32767;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhone.SelectedText = "";
            this.txtPhone.SelectionLength = 0;
            this.txtPhone.SelectionStart = 0;
            this.txtPhone.ShortcutsEnabled = true;
            this.txtPhone.Size = new System.Drawing.Size(246, 30);
            this.txtPhone.TabIndex = 105;
            this.txtPhone.UseSelectable = true;
            this.txtPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 705);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtLicenseNo);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtDriverId);
            this.Controls.Add(this.lblDriverID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewDrivers);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLicenseNo);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.pictureBoxDriver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Drivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drivers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDriver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnBack;
        private MetroFramework.Controls.MetroTextBox txtDriverId;
        private System.Windows.Forms.Label lblDriverID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewDrivers;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnRegister;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroTextBox txtFirstName;
        private System.Windows.Forms.Label lblLicenseNo;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblDriverTitle;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBoxDriver;
        private System.Windows.Forms.Label lblPhone;
        private MetroFramework.Controls.MetroTextBox txtLicenseNo;
        private MetroFramework.Controls.MetroTextBox txtPhone;
    }
}
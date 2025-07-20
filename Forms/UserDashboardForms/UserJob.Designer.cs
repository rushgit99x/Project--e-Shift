namespace e_Shift.Forms.UserDashboardForms
{
    partial class UserJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserJob));
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerJobs = new System.Windows.Forms.DateTimePicker();
            this.lblLicenseNo = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblJobsTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtJobId = new MetroFramework.Controls.MetroTextBox();
            this.lblDriverID = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewJobs = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pictureBoxDriver = new System.Windows.Forms.PictureBox();
            this.cmbStartLocation = new System.Windows.Forms.ComboBox();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDriver)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(218, 320);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(205, 161);
            this.txtDescription.TabIndex = 146;
            this.txtDescription.Text = "";
            // 
            // dateTimePickerJobs
            // 
            this.dateTimePickerJobs.Location = new System.Drawing.Point(218, 265);
            this.dateTimePickerJobs.Name = "dateTimePickerJobs";
            this.dateTimePickerJobs.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerJobs.TabIndex = 144;
            // 
            // lblLicenseNo
            // 
            this.lblLicenseNo.AutoSize = true;
            this.lblLicenseNo.BackColor = System.Drawing.Color.White;
            this.lblLicenseNo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseNo.Location = new System.Drawing.Point(34, 259);
            this.lblLicenseNo.Name = "lblLicenseNo";
            this.lblLicenseNo.Size = new System.Drawing.Size(154, 28);
            this.lblLicenseNo.TabIndex = 132;
            this.lblLicenseNo.Text = "Preferred Date";
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
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.White;
            this.lblLastName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(34, 198);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(121, 28);
            this.lblLastName.TabIndex = 131;
            this.lblLastName.Text = "Destination";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.White;
            this.lblFirstName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(34, 135);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(160, 28);
            this.lblFirstName.TabIndex = 130;
            this.lblFirstName.Text = "Pickup Location";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblJobsTitle);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1000, 44);
            this.panelTitle.TabIndex = 129;
            // 
            // lblJobsTitle
            // 
            this.lblJobsTitle.AutoSize = true;
            this.lblJobsTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobsTitle.Location = new System.Drawing.Point(21, 11);
            this.lblJobsTitle.Name = "lblJobsTitle";
            this.lblJobsTitle.Size = new System.Drawing.Size(47, 24);
            this.lblJobsTitle.TabIndex = 30;
            this.lblJobsTitle.Text = "Jobs";
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
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DeepPink;
            this.btnRegister.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(41, 493);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(171, 55);
            this.btnRegister.TabIndex = 135;
            this.btnRegister.Text = "Submit";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(34, 320);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(121, 28);
            this.lblStatus.TabIndex = 142;
            this.lblStatus.Text = "Description";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DeepPink;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(242, 552);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(171, 55);
            this.btnBack.TabIndex = 141;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtJobId
            // 
            // 
            // 
            // 
            this.txtJobId.CustomButton.Image = null;
            this.txtJobId.CustomButton.Location = new System.Drawing.Point(177, 2);
            this.txtJobId.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobId.CustomButton.Name = "";
            this.txtJobId.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtJobId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtJobId.CustomButton.TabIndex = 1;
            this.txtJobId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtJobId.CustomButton.UseSelectable = true;
            this.txtJobId.CustomButton.Visible = false;
            this.txtJobId.Lines = new string[0];
            this.txtJobId.Location = new System.Drawing.Point(218, 78);
            this.txtJobId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobId.MaxLength = 32767;
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.PasswordChar = '\0';
            this.txtJobId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtJobId.SelectedText = "";
            this.txtJobId.SelectionLength = 0;
            this.txtJobId.SelectionStart = 0;
            this.txtJobId.ShortcutsEnabled = true;
            this.txtJobId.Size = new System.Drawing.Size(205, 30);
            this.txtJobId.TabIndex = 140;
            this.txtJobId.UseSelectable = true;
            this.txtJobId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtJobId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblDriverID
            // 
            this.lblDriverID.AutoSize = true;
            this.lblDriverID.BackColor = System.Drawing.Color.White;
            this.lblDriverID.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverID.Location = new System.Drawing.Point(34, 80);
            this.lblDriverID.Name = "lblDriverID";
            this.lblDriverID.Size = new System.Drawing.Size(70, 28);
            this.lblDriverID.TabIndex = 139;
            this.lblDriverID.Text = "Job ID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepPink;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(41, 552);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 55);
            this.btnDelete.TabIndex = 138;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewJobs
            // 
            this.dataGridViewJobs.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJobs.GridColor = System.Drawing.Color.White;
            this.dataGridViewJobs.Location = new System.Drawing.Point(461, 69);
            this.dataGridViewJobs.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewJobs.Name = "dataGridViewJobs";
            this.dataGridViewJobs.RowHeadersWidth = 51;
            this.dataGridViewJobs.Size = new System.Drawing.Size(526, 577);
            this.dataGridViewJobs.TabIndex = 137;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DeepPink;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(242, 493);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(171, 55);
            this.btnEdit.TabIndex = 136;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pictureBoxDriver
            // 
            this.pictureBoxDriver.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDriver.Image")));
            this.pictureBoxDriver.Location = new System.Drawing.Point(-9, -26);
            this.pictureBoxDriver.Name = "pictureBoxDriver";
            this.pictureBoxDriver.Size = new System.Drawing.Size(1009, 727);
            this.pictureBoxDriver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDriver.TabIndex = 128;
            this.pictureBoxDriver.TabStop = false;
            // 
            // cmbStartLocation
            // 
            this.cmbStartLocation.FormattingEnabled = true;
            this.cmbStartLocation.Location = new System.Drawing.Point(218, 138);
            this.cmbStartLocation.Name = "cmbStartLocation";
            this.cmbStartLocation.Size = new System.Drawing.Size(205, 24);
            this.cmbStartLocation.TabIndex = 147;
            // 
            // cmbDestination
            // 
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(218, 202);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(205, 24);
            this.cmbDestination.TabIndex = 148;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DeepPink;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(139, 611);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(171, 55);
            this.btnClear.TabIndex = 149;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // UserJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.cmbStartLocation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dateTimePickerJobs);
            this.Controls.Add(this.lblLicenseNo);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtJobId);
            this.Controls.Add(this.lblDriverID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewJobs);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pictureBoxDriver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserJob";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDriver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerJobs;
        private System.Windows.Forms.Label lblLicenseNo;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblJobsTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnBack;
        private MetroFramework.Controls.MetroTextBox txtJobId;
        private System.Windows.Forms.Label lblDriverID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewJobs;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.PictureBox pictureBoxDriver;
        private System.Windows.Forms.ComboBox cmbStartLocation;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Button btnClear;
    }
}
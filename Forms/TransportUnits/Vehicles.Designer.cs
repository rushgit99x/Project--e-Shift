namespace e_Shift.Forms.TransportUnits
{
    partial class Vehicles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vehicles));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtLorryID = new MetroFramework.Controls.MetroTextBox();
            this.lblLorryId = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewVehicles = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtModel = new MetroFramework.Controls.MetroTextBox();
            this.txtLicensePlate = new MetroFramework.Controls.MetroTextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbCapacity = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1001, 705);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 44);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Vehicle Management";
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
            // txtLorryID
            // 
            // 
            // 
            // 
            this.txtLorryID.CustomButton.Image = null;
            this.txtLorryID.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtLorryID.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLorryID.CustomButton.Name = "";
            this.txtLorryID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLorryID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLorryID.CustomButton.TabIndex = 1;
            this.txtLorryID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLorryID.CustomButton.UseSelectable = true;
            this.txtLorryID.CustomButton.Visible = false;
            this.txtLorryID.Lines = new string[0];
            this.txtLorryID.Location = new System.Drawing.Point(185, 101);
            this.txtLorryID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLorryID.MaxLength = 32767;
            this.txtLorryID.Name = "txtLorryID";
            this.txtLorryID.PasswordChar = '\0';
            this.txtLorryID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLorryID.SelectedText = "";
            this.txtLorryID.SelectionLength = 0;
            this.txtLorryID.SelectionStart = 0;
            this.txtLorryID.ShortcutsEnabled = true;
            this.txtLorryID.Size = new System.Drawing.Size(246, 30);
            this.txtLorryID.TabIndex = 79;
            this.txtLorryID.UseSelectable = true;
            this.txtLorryID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLorryID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblLorryId
            // 
            this.lblLorryId.AutoSize = true;
            this.lblLorryId.BackColor = System.Drawing.Color.White;
            this.lblLorryId.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLorryId.Location = new System.Drawing.Point(42, 103);
            this.lblLorryId.Name = "lblLorryId";
            this.lblLorryId.Size = new System.Drawing.Size(87, 28);
            this.lblLorryId.TabIndex = 78;
            this.lblLorryId.Text = "Lorry ID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepPink;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(47, 500);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 55);
            this.btnDelete.TabIndex = 77;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewVehicles
            // 
            this.dataGridViewVehicles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVehicles.GridColor = System.Drawing.Color.White;
            this.dataGridViewVehicles.Location = new System.Drawing.Point(469, 92);
            this.dataGridViewVehicles.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewVehicles.Name = "dataGridViewVehicles";
            this.dataGridViewVehicles.RowHeadersWidth = 51;
            this.dataGridViewVehicles.Size = new System.Drawing.Size(518, 577);
            this.dataGridViewVehicles.TabIndex = 76;
            this.dataGridViewVehicles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVehicles_CellContentClick);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DeepPink;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(248, 441);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(171, 55);
            this.btnEdit.TabIndex = 75;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DeepPink;
            this.btnRegister.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(47, 441);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(171, 55);
            this.btnRegister.TabIndex = 74;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtModel
            // 
            // 
            // 
            // 
            this.txtModel.CustomButton.Image = null;
            this.txtModel.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtModel.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModel.CustomButton.Name = "";
            this.txtModel.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtModel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtModel.CustomButton.TabIndex = 1;
            this.txtModel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtModel.CustomButton.UseSelectable = true;
            this.txtModel.CustomButton.Visible = false;
            this.txtModel.Lines = new string[0];
            this.txtModel.Location = new System.Drawing.Point(185, 220);
            this.txtModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModel.MaxLength = 32767;
            this.txtModel.Name = "txtModel";
            this.txtModel.PasswordChar = '\0';
            this.txtModel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtModel.SelectedText = "";
            this.txtModel.SelectionLength = 0;
            this.txtModel.SelectionStart = 0;
            this.txtModel.ShortcutsEnabled = true;
            this.txtModel.Size = new System.Drawing.Size(246, 30);
            this.txtModel.TabIndex = 72;
            this.txtModel.UseSelectable = true;
            this.txtModel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtModel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtLicensePlate
            // 
            // 
            // 
            // 
            this.txtLicensePlate.CustomButton.Image = null;
            this.txtLicensePlate.CustomButton.Location = new System.Drawing.Point(218, 2);
            this.txtLicensePlate.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLicensePlate.CustomButton.Name = "";
            this.txtLicensePlate.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLicensePlate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLicensePlate.CustomButton.TabIndex = 1;
            this.txtLicensePlate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLicensePlate.CustomButton.UseSelectable = true;
            this.txtLicensePlate.CustomButton.Visible = false;
            this.txtLicensePlate.Lines = new string[0];
            this.txtLicensePlate.Location = new System.Drawing.Point(185, 158);
            this.txtLicensePlate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLicensePlate.MaxLength = 32767;
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.PasswordChar = '\0';
            this.txtLicensePlate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLicensePlate.SelectedText = "";
            this.txtLicensePlate.SelectionLength = 0;
            this.txtLicensePlate.SelectionStart = 0;
            this.txtLicensePlate.ShortcutsEnabled = true;
            this.txtLicensePlate.Size = new System.Drawing.Size(246, 30);
            this.txtLicensePlate.TabIndex = 71;
            this.txtLicensePlate.UseSelectable = true;
            this.txtLicensePlate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLicensePlate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.BackColor = System.Drawing.Color.White;
            this.lblCapacity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(42, 282);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(93, 28);
            this.lblCapacity.TabIndex = 70;
            this.lblCapacity.Text = "Capacity";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.BackColor = System.Drawing.Color.White;
            this.lblModel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(42, 221);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(74, 28);
            this.lblModel.TabIndex = 69;
            this.lblModel.Text = "Model";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.BackColor = System.Drawing.Color.White;
            this.lblLicensePlate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicensePlate.Location = new System.Drawing.Point(42, 158);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(137, 28);
            this.lblLicensePlate.TabIndex = 68;
            this.lblLicensePlate.Text = "License Plate";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DeepPink;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(248, 500);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(171, 55);
            this.btnBack.TabIndex = 80;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(42, 338);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 28);
            this.lblStatus.TabIndex = 81;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(185, 338);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(246, 24);
            this.cmbStatus.TabIndex = 83;
            // 
            // cmbCapacity
            // 
            this.cmbCapacity.FormattingEnabled = true;
            this.cmbCapacity.Location = new System.Drawing.Point(185, 286);
            this.cmbCapacity.Name = "cmbCapacity";
            this.cmbCapacity.Size = new System.Drawing.Size(246, 24);
            this.cmbCapacity.TabIndex = 84;
            // 
            // Vehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.cmbCapacity);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtLorryID);
            this.Controls.Add(this.lblLorryId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewVehicles);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Vehicles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicles";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox txtLorryID;
        private System.Windows.Forms.Label lblLorryId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewVehicles;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRegister;
        private MetroFramework.Controls.MetroTextBox txtModel;
        private MetroFramework.Controls.MetroTextBox txtLicensePlate;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbCapacity;
    }
}
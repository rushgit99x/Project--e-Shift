namespace e_Shift.Forms
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCustomerManagement = new FontAwesome.Sharp.IconButton();
            this.btnReports = new FontAwesome.Sharp.IconButton();
            this.btnProducts = new FontAwesome.Sharp.IconButton();
            this.btnTransportUnits = new FontAwesome.Sharp.IconButton();
            this.btnUserManagement = new FontAwesome.Sharp.IconButton();
            this.btnLoadManagement = new FontAwesome.Sharp.IconButton();
            this.btnJobs = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.lblCompletedJobs = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblActiveJobs = new System.Windows.Forms.Label();
            this.lblNewJobs = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.btnCustomerManagement);
            this.panelMenu.Controls.Add(this.btnReports);
            this.panelMenu.Controls.Add(this.btnProducts);
            this.panelMenu.Controls.Add(this.btnTransportUnits);
            this.panelMenu.Controls.Add(this.btnUserManagement);
            this.panelMenu.Controls.Add(this.btnLoadManagement);
            this.panelMenu.Controls.Add(this.btnJobs);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(2, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 700);
            this.panelMenu.TabIndex = 0;
            // 
            // btnCustomerManagement
            // 
            this.btnCustomerManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerManagement.FlatAppearance.BorderSize = 0;
            this.btnCustomerManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerManagement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomerManagement.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnCustomerManagement.IconColor = System.Drawing.Color.White;
            this.btnCustomerManagement.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomerManagement.IconSize = 32;
            this.btnCustomerManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerManagement.Location = new System.Drawing.Point(0, 560);
            this.btnCustomerManagement.Name = "btnCustomerManagement";
            this.btnCustomerManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCustomerManagement.Size = new System.Drawing.Size(220, 60);
            this.btnCustomerManagement.TabIndex = 8;
            this.btnCustomerManagement.Text = "Customer Management";
            this.btnCustomerManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomerManagement.UseVisualStyleBackColor = true;
            this.btnCustomerManagement.Click += new System.EventHandler(this.btnCustomerManagement_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReports.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnReports.IconColor = System.Drawing.Color.White;
            this.btnReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReports.IconSize = 32;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 500);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(220, 60);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProducts.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            this.btnProducts.IconColor = System.Drawing.Color.White;
            this.btnProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProducts.IconSize = 32;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(0, 440);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(220, 60);
            this.btnProducts.TabIndex = 6;
            this.btnProducts.Text = "Products";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnTransportUnits
            // 
            this.btnTransportUnits.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransportUnits.FlatAppearance.BorderSize = 0;
            this.btnTransportUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransportUnits.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransportUnits.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTransportUnits.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnTransportUnits.IconColor = System.Drawing.Color.White;
            this.btnTransportUnits.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTransportUnits.IconSize = 32;
            this.btnTransportUnits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransportUnits.Location = new System.Drawing.Point(0, 380);
            this.btnTransportUnits.Name = "btnTransportUnits";
            this.btnTransportUnits.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTransportUnits.Size = new System.Drawing.Size(220, 60);
            this.btnTransportUnits.TabIndex = 5;
            this.btnTransportUnits.Text = "Transport Units";
            this.btnTransportUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransportUnits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransportUnits.UseVisualStyleBackColor = true;
            this.btnTransportUnits.Click += new System.EventHandler(this.btnTransportUnits_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUserManagement.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnUserManagement.IconColor = System.Drawing.Color.White;
            this.btnUserManagement.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUserManagement.IconSize = 32;
            this.btnUserManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 320);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(220, 60);
            this.btnUserManagement.TabIndex = 4;
            this.btnUserManagement.Text = "Admin Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnLoadManagement
            // 
            this.btnLoadManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadManagement.FlatAppearance.BorderSize = 0;
            this.btnLoadManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadManagement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLoadManagement.IconChar = FontAwesome.Sharp.IconChar.ListCheck;
            this.btnLoadManagement.IconColor = System.Drawing.Color.White;
            this.btnLoadManagement.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLoadManagement.IconSize = 32;
            this.btnLoadManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadManagement.Location = new System.Drawing.Point(0, 260);
            this.btnLoadManagement.Name = "btnLoadManagement";
            this.btnLoadManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLoadManagement.Size = new System.Drawing.Size(220, 60);
            this.btnLoadManagement.TabIndex = 3;
            this.btnLoadManagement.Text = "Load Management";
            this.btnLoadManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadManagement.UseVisualStyleBackColor = true;
            this.btnLoadManagement.Click += new System.EventHandler(this.btnLoadManagement_Click);
            // 
            // btnJobs
            // 
            this.btnJobs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnJobs.FlatAppearance.BorderSize = 0;
            this.btnJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobs.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobs.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnJobs.IconChar = FontAwesome.Sharp.IconChar.Briefcase;
            this.btnJobs.IconColor = System.Drawing.Color.White;
            this.btnJobs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnJobs.IconSize = 32;
            this.btnJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobs.Location = new System.Drawing.Point(0, 200);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobs.Size = new System.Drawing.Size(220, 60);
            this.btnJobs.TabIndex = 2;
            this.btnJobs.Text = "Jobs";
            this.btnJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnJobs.UseVisualStyleBackColor = true;
            this.btnJobs.Click += new System.EventHandler(this.btnJobs_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnDashboard.IconColor = System.Drawing.Color.White;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 32;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 140);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(220, 60);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(33, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(147, 134);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(222, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(778, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Snow;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnMinimize.Location = new System.Drawing.Point(695, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 27;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(61, 34);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(48, 16);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Snow;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClose.Location = new System.Drawing.Point(736, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(22, 28);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(222, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(778, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Controls.Add(this.lblCompletedJobs);
            this.panelDesktop.Controls.Add(this.lblTotalCustomers);
            this.panelDesktop.Controls.Add(this.lblActiveJobs);
            this.panelDesktop.Controls.Add(this.lblNewJobs);
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Location = new System.Drawing.Point(222, 84);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(778, 616);
            this.panelDesktop.TabIndex = 3;
            // 
            // lblCompletedJobs
            // 
            this.lblCompletedJobs.AutoSize = true;
            this.lblCompletedJobs.BackColor = System.Drawing.Color.White;
            this.lblCompletedJobs.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedJobs.Location = new System.Drawing.Point(411, 393);
            this.lblCompletedJobs.Name = "lblCompletedJobs";
            this.lblCompletedJobs.Size = new System.Drawing.Size(83, 97);
            this.lblCompletedJobs.TabIndex = 9;
            this.lblCompletedJobs.Text = "0";
            this.lblCompletedJobs.Click += new System.EventHandler(this.lblCompletedJobs_Click);
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.BackColor = System.Drawing.Color.White;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.Location = new System.Drawing.Point(34, 393);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(83, 97);
            this.lblTotalCustomers.TabIndex = 8;
            this.lblTotalCustomers.Text = "0";
            this.lblTotalCustomers.Click += new System.EventHandler(this.lblTotalCustomers_Click);
            // 
            // lblActiveJobs
            // 
            this.lblActiveJobs.AutoSize = true;
            this.lblActiveJobs.BackColor = System.Drawing.Color.White;
            this.lblActiveJobs.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveJobs.Location = new System.Drawing.Point(411, 154);
            this.lblActiveJobs.Name = "lblActiveJobs";
            this.lblActiveJobs.Size = new System.Drawing.Size(83, 97);
            this.lblActiveJobs.TabIndex = 7;
            this.lblActiveJobs.Text = "0";
            this.lblActiveJobs.Click += new System.EventHandler(this.lblActiveJobs_Click);
            // 
            // lblNewJobs
            // 
            this.lblNewJobs.AutoSize = true;
            this.lblNewJobs.BackColor = System.Drawing.Color.White;
            this.lblNewJobs.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewJobs.Location = new System.Drawing.Point(48, 154);
            this.lblNewJobs.Name = "lblNewJobs";
            this.lblNewJobs.Size = new System.Drawing.Size(83, 97);
            this.lblNewJobs.TabIndex = 6;
            this.lblNewJobs.Text = "0";
            this.lblNewJobs.Click += new System.EventHandler(this.lblNewJobs_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(780, 615);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnReports;
        private FontAwesome.Sharp.IconButton btnProducts;
        private FontAwesome.Sharp.IconButton btnTransportUnits;
        private FontAwesome.Sharp.IconButton btnUserManagement;
        private FontAwesome.Sharp.IconButton btnLoadManagement;
        private FontAwesome.Sharp.IconButton btnJobs;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label lblCompletedJobs;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblActiveJobs;
        private System.Windows.Forms.Label lblNewJobs;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnCustomerManagement;
    }
}
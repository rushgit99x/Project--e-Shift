namespace e_Shift.Forms
{
    partial class AdminSummeryDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSummeryDashboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNewJobs = new System.Windows.Forms.Label();
            this.lblActiveJobs = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblCompletedJobs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(780, 615);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblNewJobs
            // 
            this.lblNewJobs.AutoSize = true;
            this.lblNewJobs.BackColor = System.Drawing.Color.White;
            this.lblNewJobs.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewJobs.Location = new System.Drawing.Point(49, 153);
            this.lblNewJobs.Name = "lblNewJobs";
            this.lblNewJobs.Size = new System.Drawing.Size(83, 97);
            this.lblNewJobs.TabIndex = 1;
            this.lblNewJobs.Text = "0";
            this.lblNewJobs.Click += new System.EventHandler(this.lblNewJobs_Click);
            // 
            // lblActiveJobs
            // 
            this.lblActiveJobs.AutoSize = true;
            this.lblActiveJobs.BackColor = System.Drawing.Color.White;
            this.lblActiveJobs.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveJobs.Location = new System.Drawing.Point(412, 153);
            this.lblActiveJobs.Name = "lblActiveJobs";
            this.lblActiveJobs.Size = new System.Drawing.Size(83, 97);
            this.lblActiveJobs.TabIndex = 2;
            this.lblActiveJobs.Text = "0";
            this.lblActiveJobs.Click += new System.EventHandler(this.lblActiveJobs_Click);
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.BackColor = System.Drawing.Color.White;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.Location = new System.Drawing.Point(35, 392);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(83, 97);
            this.lblTotalCustomers.TabIndex = 3;
            this.lblTotalCustomers.Text = "0";
            this.lblTotalCustomers.Click += new System.EventHandler(this.lblTotalCustomers_Click);
            // 
            // lblCompletedJobs
            // 
            this.lblCompletedJobs.AutoSize = true;
            this.lblCompletedJobs.BackColor = System.Drawing.Color.White;
            this.lblCompletedJobs.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedJobs.Location = new System.Drawing.Point(412, 392);
            this.lblCompletedJobs.Name = "lblCompletedJobs";
            this.lblCompletedJobs.Size = new System.Drawing.Size(83, 97);
            this.lblCompletedJobs.TabIndex = 4;
            this.lblCompletedJobs.Text = "0";
            this.lblCompletedJobs.Click += new System.EventHandler(this.lblCompletedJobs_Click);
            // 
            // AdminSummeryDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 620);
            this.Controls.Add(this.lblCompletedJobs);
            this.Controls.Add(this.lblTotalCustomers);
            this.Controls.Add(this.lblActiveJobs);
            this.Controls.Add(this.lblNewJobs);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminSummeryDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminSummeryDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNewJobs;
        private System.Windows.Forms.Label lblActiveJobs;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblCompletedJobs;
    }
}
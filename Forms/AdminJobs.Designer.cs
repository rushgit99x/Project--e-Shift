namespace e_Shift.Forms
{
    partial class AdminJobs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminJobs));
            this.btnApprovedJobs = new System.Windows.Forms.PictureBox();
            this.btnReviewJobs = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnApprovedJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReviewJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApprovedJobs
            // 
            this.btnApprovedJobs.Image = ((System.Drawing.Image)(resources.GetObject("btnApprovedJobs.Image")));
            this.btnApprovedJobs.Location = new System.Drawing.Point(413, 141);
            this.btnApprovedJobs.Name = "btnApprovedJobs";
            this.btnApprovedJobs.Size = new System.Drawing.Size(250, 250);
            this.btnApprovedJobs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnApprovedJobs.TabIndex = 5;
            this.btnApprovedJobs.TabStop = false;
            this.btnApprovedJobs.Click += new System.EventHandler(this.btnApprovedJobs_Click);
            // 
            // btnReviewJobs
            // 
            this.btnReviewJobs.Image = ((System.Drawing.Image)(resources.GetObject("btnReviewJobs.Image")));
            this.btnReviewJobs.Location = new System.Drawing.Point(97, 141);
            this.btnReviewJobs.Name = "btnReviewJobs";
            this.btnReviewJobs.Size = new System.Drawing.Size(250, 250);
            this.btnReviewJobs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnReviewJobs.TabIndex = 4;
            this.btnReviewJobs.TabStop = false;
            this.btnReviewJobs.Click += new System.EventHandler(this.btnReviewJobs_Click);
            // 
            // AdminJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(760, 569);
            this.Controls.Add(this.btnApprovedJobs);
            this.Controls.Add(this.btnReviewJobs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminJobs";
            this.Text = "AdminJobs";
            ((System.ComponentModel.ISupportInitialize)(this.btnApprovedJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReviewJobs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnApprovedJobs;
        private System.Windows.Forms.PictureBox btnReviewJobs;
    }
}
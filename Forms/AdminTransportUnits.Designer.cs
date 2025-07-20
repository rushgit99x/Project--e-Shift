namespace e_Shift.Forms
{
    partial class AdminTransportUnits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTransportUnits));
            this.btnVehicle = new System.Windows.Forms.PictureBox();
            this.btnDriver = new System.Windows.Forms.PictureBox();
            this.btnContainer = new System.Windows.Forms.PictureBox();
            this.btnAssistant = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAssistant)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVehicle
            // 
            this.btnVehicle.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicle.Image")));
            this.btnVehicle.Location = new System.Drawing.Point(111, 50);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(250, 250);
            this.btnVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVehicle.TabIndex = 0;
            this.btnVehicle.TabStop = false;
            this.btnVehicle.Click += new System.EventHandler(this.btnVehicle_Click);
            // 
            // btnDriver
            // 
            this.btnDriver.Image = ((System.Drawing.Image)(resources.GetObject("btnDriver.Image")));
            this.btnDriver.Location = new System.Drawing.Point(427, 50);
            this.btnDriver.Name = "btnDriver";
            this.btnDriver.Size = new System.Drawing.Size(250, 250);
            this.btnDriver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDriver.TabIndex = 1;
            this.btnDriver.TabStop = false;
            this.btnDriver.Click += new System.EventHandler(this.btnDriver_Click);
            // 
            // btnContainer
            // 
            this.btnContainer.Image = ((System.Drawing.Image)(resources.GetObject("btnContainer.Image")));
            this.btnContainer.Location = new System.Drawing.Point(427, 320);
            this.btnContainer.Name = "btnContainer";
            this.btnContainer.Size = new System.Drawing.Size(250, 250);
            this.btnContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnContainer.TabIndex = 3;
            this.btnContainer.TabStop = false;
            this.btnContainer.Click += new System.EventHandler(this.btnContainer_Click);
            // 
            // btnAssistant
            // 
            this.btnAssistant.Image = ((System.Drawing.Image)(resources.GetObject("btnAssistant.Image")));
            this.btnAssistant.Location = new System.Drawing.Point(111, 320);
            this.btnAssistant.Name = "btnAssistant";
            this.btnAssistant.Size = new System.Drawing.Size(250, 250);
            this.btnAssistant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAssistant.TabIndex = 2;
            this.btnAssistant.TabStop = false;
            this.btnAssistant.Click += new System.EventHandler(this.btnAssistant_Click);
            // 
            // AdminTransportUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(778, 616);
            this.Controls.Add(this.btnContainer);
            this.Controls.Add(this.btnAssistant);
            this.Controls.Add(this.btnDriver);
            this.Controls.Add(this.btnVehicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminTransportUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminTransportUnits";
            ((System.ComponentModel.ISupportInitialize)(this.btnVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAssistant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnVehicle;
        private System.Windows.Forms.PictureBox btnDriver;
        private System.Windows.Forms.PictureBox btnContainer;
        private System.Windows.Forms.PictureBox btnAssistant;
    }
}
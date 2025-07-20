namespace e_Shift.Forms
{
    partial class AdminProducts
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
            this.txtProductsList = new System.Windows.Forms.RichTextBox();
            this.txtProductListID = new MetroFramework.Controls.MetroTextBox();
            this.lblProductListId = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCreatedByAdminID = new MetroFramework.Controls.MetroTextBox();
            this.txtWeight = new MetroFramework.Controls.MetroTextBox();
            this.lblCreatedByAdminID = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblProductList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductsList
            // 
            this.txtProductsList.Location = new System.Drawing.Point(264, 71);
            this.txtProductsList.Name = "txtProductsList";
            this.txtProductsList.Size = new System.Drawing.Size(435, 112);
            this.txtProductsList.TabIndex = 93;
            this.txtProductsList.Text = "";
            // 
            // txtProductListID
            // 
            // 
            // 
            // 
            this.txtProductListID.CustomButton.Image = null;
            this.txtProductListID.CustomButton.Location = new System.Drawing.Point(407, 2);
            this.txtProductListID.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductListID.CustomButton.Name = "";
            this.txtProductListID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtProductListID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductListID.CustomButton.TabIndex = 1;
            this.txtProductListID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductListID.CustomButton.UseSelectable = true;
            this.txtProductListID.CustomButton.Visible = false;
            this.txtProductListID.Lines = new string[0];
            this.txtProductListID.Location = new System.Drawing.Point(264, 21);
            this.txtProductListID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductListID.MaxLength = 32767;
            this.txtProductListID.Name = "txtProductListID";
            this.txtProductListID.PasswordChar = '\0';
            this.txtProductListID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductListID.SelectedText = "";
            this.txtProductListID.SelectionLength = 0;
            this.txtProductListID.SelectionStart = 0;
            this.txtProductListID.ShortcutsEnabled = true;
            this.txtProductListID.Size = new System.Drawing.Size(435, 30);
            this.txtProductListID.TabIndex = 92;
            this.txtProductListID.UseSelectable = true;
            this.txtProductListID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProductListID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblProductListId
            // 
            this.lblProductListId.AutoSize = true;
            this.lblProductListId.BackColor = System.Drawing.Color.Transparent;
            this.lblProductListId.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductListId.ForeColor = System.Drawing.Color.Black;
            this.lblProductListId.Location = new System.Drawing.Point(62, 21);
            this.lblProductListId.Name = "lblProductListId";
            this.lblProductListId.Size = new System.Drawing.Size(150, 28);
            this.lblProductListId.TabIndex = 91;
            this.lblProductListId.Text = "Product List ID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepPink;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(528, 302);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 55);
            this.btnDelete.TabIndex = 90;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.GridColor = System.Drawing.Color.White;
            this.dataGridViewProducts.Location = new System.Drawing.Point(176, 379);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.Size = new System.Drawing.Size(522, 177);
            this.dataGridViewProducts.TabIndex = 89;
            this.dataGridViewProducts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentDoubleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DeepPink;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(352, 302);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(171, 55);
            this.btnUpdate.TabIndex = 88;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepPink;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(176, 302);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(171, 55);
            this.btnAdd.TabIndex = 87;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCreatedByAdminID
            // 
            // 
            // 
            // 
            this.txtCreatedByAdminID.CustomButton.Image = null;
            this.txtCreatedByAdminID.CustomButton.Location = new System.Drawing.Point(407, 2);
            this.txtCreatedByAdminID.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCreatedByAdminID.CustomButton.Name = "";
            this.txtCreatedByAdminID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtCreatedByAdminID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCreatedByAdminID.CustomButton.TabIndex = 1;
            this.txtCreatedByAdminID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCreatedByAdminID.CustomButton.UseSelectable = true;
            this.txtCreatedByAdminID.CustomButton.Visible = false;
            this.txtCreatedByAdminID.Lines = new string[0];
            this.txtCreatedByAdminID.Location = new System.Drawing.Point(263, 250);
            this.txtCreatedByAdminID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCreatedByAdminID.MaxLength = 32767;
            this.txtCreatedByAdminID.Name = "txtCreatedByAdminID";
            this.txtCreatedByAdminID.PasswordChar = '\0';
            this.txtCreatedByAdminID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCreatedByAdminID.SelectedText = "";
            this.txtCreatedByAdminID.SelectionLength = 0;
            this.txtCreatedByAdminID.SelectionStart = 0;
            this.txtCreatedByAdminID.ShortcutsEnabled = true;
            this.txtCreatedByAdminID.Size = new System.Drawing.Size(435, 30);
            this.txtCreatedByAdminID.TabIndex = 86;
            this.txtCreatedByAdminID.UseSelectable = true;
            this.txtCreatedByAdminID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCreatedByAdminID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.txtWeight.Location = new System.Drawing.Point(263, 204);
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
            this.txtWeight.TabIndex = 85;
            this.txtWeight.UseSelectable = true;
            this.txtWeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtWeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCreatedByAdminID
            // 
            this.lblCreatedByAdminID.AutoSize = true;
            this.lblCreatedByAdminID.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedByAdminID.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByAdminID.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedByAdminID.Location = new System.Drawing.Point(62, 250);
            this.lblCreatedByAdminID.Name = "lblCreatedByAdminID";
            this.lblCreatedByAdminID.Size = new System.Drawing.Size(195, 28);
            this.lblCreatedByAdminID.TabIndex = 84;
            this.lblCreatedByAdminID.Text = "CreatedByAdminID";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.BackColor = System.Drawing.Color.Transparent;
            this.lblWeight.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.ForeColor = System.Drawing.Color.Black;
            this.lblWeight.Location = new System.Drawing.Point(62, 204);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(81, 28);
            this.lblWeight.TabIndex = 83;
            this.lblWeight.Text = "Weight";
            // 
            // lblProductList
            // 
            this.lblProductList.AutoSize = true;
            this.lblProductList.BackColor = System.Drawing.Color.Transparent;
            this.lblProductList.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductList.ForeColor = System.Drawing.Color.Black;
            this.lblProductList.Location = new System.Drawing.Point(62, 76);
            this.lblProductList.Name = "lblProductList";
            this.lblProductList.Size = new System.Drawing.Size(133, 28);
            this.lblProductList.TabIndex = 82;
            this.lblProductList.Text = "Products List";
            // 
            // AdminProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(760, 569);
            this.Controls.Add(this.txtProductsList);
            this.Controls.Add(this.txtProductListID);
            this.Controls.Add(this.lblProductListId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCreatedByAdminID);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblCreatedByAdminID);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblProductList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminProducts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtProductsList;
        private MetroFramework.Controls.MetroTextBox txtProductListID;
        private System.Windows.Forms.Label lblProductListId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private MetroFramework.Controls.MetroTextBox txtCreatedByAdminID;
        private MetroFramework.Controls.MetroTextBox txtWeight;
        private System.Windows.Forms.Label lblCreatedByAdminID;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblProductList;
    }
}
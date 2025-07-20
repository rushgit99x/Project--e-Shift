using System;
using System.Windows.Forms;
using e_Shift.Business.Interface;
using e_Shift.Models;

namespace e_Shift.Forms
{
    public partial class AdminProducts : Form
    {
        private readonly IProductService _productService;

        public AdminProducts(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            this.Text = "Products";
            txtProductListID.ReadOnly = true;
            dataGridViewProducts.ReadOnly = true;
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                dataGridViewProducts.DataSource = products;

                dataGridViewProducts.Columns["ProductsListID"].HeaderText = "Product List ID";
                dataGridViewProducts.Columns["ProductsList"].HeaderText = "Products List";
                dataGridViewProducts.Columns["Weight"].HeaderText = "Weight (kg)";
                dataGridViewProducts.Columns["CreatedByAdminID"].HeaderText = "Created By Admin ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                ProductsList = txtProductsList.Text.Trim(),
                Weight = decimal.Parse(txtWeight.Text),
                CreatedByAdminID = int.Parse(txtCreatedByAdminID.Text)
            };

            if (!ValidateInputs(product)) return;

            try
            {
                _productService.AddProduct(product);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductListID.Text))
            {
                MessageBox.Show("Please select a product to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = new Product
            {
                ProductsListID = int.Parse(txtProductListID.Text),
                ProductsList = txtProductsList.Text.Trim(),
                Weight = decimal.Parse(txtWeight.Text),
                CreatedByAdminID = int.Parse(txtCreatedByAdminID.Text)
            };

            if (!ValidateInputs(product)) return;

            try
            {
                if (_productService.UpdateProduct(product))
                {
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("No product found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductListID.Text))
            {
                MessageBox.Show("Please select a product to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtProductListID.Text, out int productId))
            {
                MessageBox.Show("Invalid Product List ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                if (_productService.DeleteProduct(productId))
                {
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("No product found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewProducts.Rows[e.RowIndex];
                txtProductListID.Text = row.Cells["ProductsListID"].Value.ToString();
                txtProductsList.Text = row.Cells["ProductsList"].Value.ToString();
                txtWeight.Text = row.Cells["Weight"].Value.ToString();
                txtCreatedByAdminID.Text = row.Cells["CreatedByAdminID"].Value.ToString();
            }
        }

        private bool ValidateInputs(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductsList) ||
                string.IsNullOrWhiteSpace(txtWeight.Text) ||
                string.IsNullOrWhiteSpace(txtCreatedByAdminID.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtWeight.Text, out decimal weight))
            {
                MessageBox.Show("Weight must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtCreatedByAdminID.Text, out int adminId))
            {
                MessageBox.Show("Created By Admin ID must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return _productService.ValidateProduct(product, out string errorMessage);
        }

        private void ClearInputs()
        {
            txtProductListID.Text = "";
            txtProductsList.Text = "";
            txtWeight.Text = "";
            txtCreatedByAdminID.Text = "";
        }
    }
}
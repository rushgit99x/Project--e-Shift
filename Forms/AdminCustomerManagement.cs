using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Models;
using System;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class AdminCustomerManagement : Form
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerManagement()
        {
            InitializeComponent();
            _customerService = new CustomerService(); // Dependency injection could be used here
            dataGridViewCustomers.ReadOnly = true; // Make DataGridView read-only
            LoadCustomers(); // Load customers when form initializes
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                dataGridViewCustomers.DataSource = customers;

                // Customize DataGridView columns
                dataGridViewCustomers.Columns["CustomerID"].HeaderText = "ID";
                dataGridViewCustomers.Columns["CustomerNumber"].HeaderText = "Customer Number";
                dataGridViewCustomers.Columns["FirstName"].HeaderText = "First Name";
                dataGridViewCustomers.Columns["LastName"].HeaderText = "Last Name";
                dataGridViewCustomers.Columns["Email"].HeaderText = "Email";
                dataGridViewCustomers.Columns["Phone"].HeaderText = "Phone";
                dataGridViewCustomers.Columns["Address"].HeaderText = "Address";
                dataGridViewCustomers.Columns["RegistrationDate"].HeaderText = "Registration Date";

                // Adjust column widths
                dataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected customer ID
            int customerId = Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells["CustomerID"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool canDelete = _customerService.CanDeleteCustomer(customerId);
                    if (!canDelete)
                    {
                        MessageBox.Show("Cannot delete customer with associated jobs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _customerService.DeleteCustomer(customerId);
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers(); // Refresh the customer list
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int customerId = Convert.ToInt32(dataGridViewCustomers.Rows[e.RowIndex].Cells["CustomerID"].Value);
                MessageBox.Show($"Selected Customer ID: {customerId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
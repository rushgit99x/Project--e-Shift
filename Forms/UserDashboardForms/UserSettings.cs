using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using e_Shift.Common;
using e_Shift.Config;

namespace e_Shift.Forms.UserDashboardForms
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                // Check if user is logged in
                if (!SessionManager.IsLoggedIn)
                {
                    MessageBox.Show("Please log in first.", "Authentication Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Load current customer data into text boxes
                var customer = SessionManager.CurrentCustomer;
                txtCustomerID.Text = customer.CustomerNumber;
                txtFirstName.Text = customer.FirstName;
                txtLastName.Text = customer.LastName;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Address;

                // Make CustomerID non-editable
                txtCustomerID.ReadOnly = true;
                txtCustomerID.BackColor = SystemColors.Control; // Gray background to indicate non-editable
                txtCustomerID.TabStop = false; // Remove from tab order

                // Load data into DataGridView
                LoadCustomerDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerDataGrid()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT CustomerNumber as 'Customer ID', 
                                           FirstName as 'First Name', 
                                           LastName as 'Last Name', 
                                           Email, 
                                           Phone, 
                                           Address, 
                                           RegistrationDate as 'Registration Date' 
                                    FROM customers 
                                    WHERE CustomerID = @CustomerID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewSettings.DataSource = dataTable;
                        dataGridViewSettings.ReadOnly = true;
                        dataGridViewSettings.AllowUserToAddRows = false;
                        dataGridViewSettings.AllowUserToDeleteRows = false;
                        dataGridViewSettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data grid: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Check if email already exists for another customer
            if (IsEmailExists(txtEmail.Text, SessionManager.CurrentCustomer.CustomerID))
            {
                MessageBox.Show("This email address is already registered with another account.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsEmailExists(string email, int excludeCustomerID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM customers WHERE Email = @Email AND CustomerID != @CustomerID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@CustomerID", excludeCustomerID);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking email: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Return true to prevent update in case of error
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager.IsLoggedIn)
                {
                    MessageBox.Show("Please log in first.", "Authentication Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput())
                {
                    return;
                }

                // Confirm update
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to update your account information?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // Update customer data in database
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE customers 
                                    SET FirstName = @FirstName, 
                                        LastName = @LastName, 
                                        Email = @Email, 
                                        Phone = @Phone, 
                                        Address = @Address 
                                    WHERE CustomerID = @CustomerID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        command.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update session data
                            SessionManager.CurrentCustomer.FirstName = txtFirstName.Text.Trim();
                            SessionManager.CurrentCustomer.LastName = txtLastName.Text.Trim();
                            SessionManager.CurrentCustomer.Email = txtEmail.Text.Trim();
                            SessionManager.CurrentCustomer.Phone = txtPhone.Text.Trim();
                            SessionManager.CurrentCustomer.Address = txtAddress.Text.Trim();

                            MessageBox.Show("Account information updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data grid
                            LoadCustomerDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update account information.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating account: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UsersDashboard dashboard = new UsersDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters and common punctuation for names
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '\'')
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters and common punctuation for names
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '\'')
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, spaces, dashes, and parentheses for phone numbers
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }

        private void dataGridViewSettings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle double-click on data grid if needed
            // For example, you could load the selected row data into text boxes
            // This is already done in LoadCustomerData(), so this is optional
        }
    }
}
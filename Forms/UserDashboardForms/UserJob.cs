using e_Shift.Common;
using e_Shift.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Shift.Forms.UserDashboardForms
{
    public partial class UserJob : Form
    {
        private string connectionString = DBConnection.ConnectionString;

        public UserJob()
        {
            InitializeComponent();
            txtJobId.Enabled = false;
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to access this form.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            dataGridViewJobs.ReadOnly = true; // Set DataGridView to read-only
            dataGridViewJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select entire row
            dataGridViewJobs.MultiSelect = false; // Allow only single row selection

            // Configure ComboBoxes and DateTimePicker
            ConfigureControls();

            LoadJobs(); // Load jobs when form initializes
            PopulateComboBoxes(); // Populate start location and destination combo boxes
            dataGridViewJobs.SelectionChanged += DataGridViewJobs_SelectionChanged; // Add selection event handler
        }

        // Configure ComboBoxes and DateTimePicker restrictions
        private void ConfigureControls()
        {
            // Set ComboBoxes to DropDownList style to prevent manual entry
            cmbStartLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestination.DropDownStyle = ComboBoxStyle.DropDownList;

            // Set DateTimePicker to not allow past dates
            dateTimePickerJobs.MinDate = DateTime.Today;
            dateTimePickerJobs.Value = DateTime.Today;
        }

        // Populate combo boxes with sample locations (can be modified to fetch from a table if needed)
        private void PopulateComboBoxes()
        {
            // Clear existing items first
            cmbStartLocation.Items.Clear();
            cmbDestination.Items.Clear();

            // Example locations; replace with actual data source if available
            cmbStartLocation.Items.AddRange(new string[] { "Galle", "Matara", "Colombo", "Kandy", "Jaffna" });
            cmbDestination.Items.AddRange(new string[] { "Galle", "Matara", "Colombo", "Kandy", "Jaffna" });
        }

        // Load jobs for the logged-in customer into DataGridView
        private void LoadJobs()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT JobID, JobNumber, StartLocation, Destination, Status, CreatedAt, UpdatedAt, Description, PreferredDate " +
                                   "FROM jobs WHERE CustomerID = @CustomerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewJobs.DataSource = dt;
                    dataGridViewJobs.Columns["JobID"].HeaderText = "Job ID";
                    dataGridViewJobs.Columns["JobNumber"].HeaderText = "Job Number";
                    dataGridViewJobs.Columns["StartLocation"].HeaderText = "Start Location";
                    dataGridViewJobs.Columns["Destination"].HeaderText = "Destination";
                    dataGridViewJobs.Columns["Status"].HeaderText = "Status";
                    dataGridViewJobs.Columns["CreatedAt"].HeaderText = "Created At";
                    dataGridViewJobs.Columns["UpdatedAt"].HeaderText = "Updated At";
                    dataGridViewJobs.Columns["Description"].HeaderText = "Description";
                    dataGridViewJobs.Columns["PreferredDate"].HeaderText = "Preferred Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle DataGridView row selection to populate input fields
        private void DataGridViewJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewJobs.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewJobs.SelectedRows[0];
                txtJobId.Text = row.Cells["JobID"].Value?.ToString();

                // Set ComboBox values (find and select the item)
                string startLocation = row.Cells["StartLocation"].Value?.ToString();
                string destination = row.Cells["Destination"].Value?.ToString();

                if (!string.IsNullOrEmpty(startLocation))
                {
                    int startIndex = cmbStartLocation.FindStringExact(startLocation);
                    if (startIndex != -1)
                        cmbStartLocation.SelectedIndex = startIndex;
                }

                if (!string.IsNullOrEmpty(destination))
                {
                    int destIndex = cmbDestination.FindStringExact(destination);
                    if (destIndex != -1)
                        cmbDestination.SelectedIndex = destIndex;
                }

                txtDescription.Text = row.Cells["Description"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["PreferredDate"].Value?.ToString(), out DateTime preferredDate))
                {
                    // Only set the date if it's not in the past
                    if (preferredDate.Date >= DateTime.Today)
                    {
                        dateTimePickerJobs.Value = preferredDate;
                    }
                    else
                    {
                        dateTimePickerJobs.Value = DateTime.Today;
                    }
                }
                else
                {
                    dateTimePickerJobs.Value = DateTime.Today;
                }

                // Check if job is editable
                string status = row.Cells["Status"].Value?.ToString();
                if (status != "Pending")
                {
                    MessageBox.Show("Only jobs in 'Pending' status can be edited.", "Edit Restriction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                ClearInputs();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        // Generate unique JobNumber
        private string GenerateJobNumber()
        {
            return $"JOB{DateTime.Now:yyyyMMddHHmmss}";
        }

        // Register a new job
        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Validate input
                if (cmbStartLocation.SelectedIndex == -1 ||
                    cmbDestination.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if start location and destination are the same
                if (cmbStartLocation.SelectedItem.ToString() == cmbDestination.SelectedItem.ToString())
                {
                    MessageBox.Show("Start location and destination cannot be the same.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO jobs (JobNumber, CustomerID, StartLocation, Destination, Status, Description, PreferredDate) " +
                                   "VALUES (@JobNumber, @CustomerID, @StartLocation, @Destination, 'Pending', @Description, @PreferredDate)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobNumber", GenerateJobNumber());
                    cmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);
                    cmd.Parameters.AddWithValue("@StartLocation", cmbStartLocation.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Destination", cmbDestination.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@PreferredDate", dateTimePickerJobs.Value.Date);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Job registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadJobs(); // Refresh DataGridView
                    ClearInputs();
                    dataGridViewJobs.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fetch job details by JobID and populate fields
        private void btnFetchJob_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobId.Text) || !int.TryParse(txtJobId.Text, out int jobId))
            {
                MessageBox.Show("Please enter a valid Job ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StartLocation, Destination, Description, PreferredDate, Status " +
                                   "FROM jobs WHERE JobID = @JobID AND CustomerID = @CustomerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);
                    cmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["Status"].ToString() != "Pending")
                            {
                                MessageBox.Show("Only jobs in 'Pending' status can be edited.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ClearInputs();
                                btnEdit.Enabled = false;
                                btnDelete.Enabled = false;
                                return;
                            }

                            // Set ComboBox values
                            string startLocation = reader["StartLocation"].ToString();
                            string destination = reader["Destination"].ToString();

                            int startIndex = cmbStartLocation.FindStringExact(startLocation);
                            if (startIndex != -1)
                                cmbStartLocation.SelectedIndex = startIndex;

                            int destIndex = cmbDestination.FindStringExact(destination);
                            if (destIndex != -1)
                                cmbDestination.SelectedIndex = destIndex;

                            txtDescription.Text = reader["Description"].ToString();

                            if (DateTime.TryParse(reader["PreferredDate"].ToString(), out DateTime preferredDate))
                            {
                                // Only set the date if it's not in the past
                                if (preferredDate.Date >= DateTime.Today)
                                {
                                    dateTimePickerJobs.Value = preferredDate;
                                }
                                else
                                {
                                    dateTimePickerJobs.Value = DateTime.Today;
                                }
                            }
                            else
                            {
                                dateTimePickerJobs.Value = DateTime.Today;
                            }

                            btnEdit.Enabled = true;
                            btnDelete.Enabled = true;

                            // Highlight the selected job in DataGridView
                            foreach (DataGridViewRow row in dataGridViewJobs.Rows)
                            {
                                if (Convert.ToInt32(row.Cells["JobID"].Value) == jobId)
                                {
                                    row.Selected = true;
                                    dataGridViewJobs.FirstDisplayedScrollingRowIndex = row.Index;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No job found with the specified Job ID or you don't have permission to edit this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearInputs();
                            btnEdit.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Edit job based on JobID
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobId.Text) || !int.TryParse(txtJobId.Text, out int jobId))
            {
                MessageBox.Show("Please enter a valid Job ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validate input
                if (cmbStartLocation.SelectedIndex == -1 ||
                    cmbDestination.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if start location and destination are the same
                if (cmbStartLocation.SelectedItem.ToString() == cmbDestination.SelectedItem.ToString())
                {
                    MessageBox.Show("Start location and destination cannot be the same.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Check status before updating
                    string checkQuery = "SELECT Status FROM jobs WHERE JobID = @JobID AND CustomerID = @CustomerID";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@JobID", jobId);
                    checkCmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                    object statusResult = checkCmd.ExecuteScalar();
                    if (statusResult == null)
                    {
                        MessageBox.Show("No job found with the specified Job ID or you don't have permission to edit this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (statusResult.ToString() != "Pending")
                    {
                        MessageBox.Show("Only jobs in 'Pending' status can be edited.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update job
                    string updateQuery = "UPDATE jobs SET StartLocation = @StartLocation, Destination = @Destination, Description = @Description, " +
                                        "PreferredDate = @PreferredDate WHERE JobID = @JobID AND CustomerID = @CustomerID";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@StartLocation", cmbStartLocation.SelectedItem.ToString());
                    updateCmd.Parameters.AddWithValue("@Destination", cmbDestination.SelectedItem.ToString());
                    updateCmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    updateCmd.Parameters.AddWithValue("@PreferredDate", dateTimePickerJobs.Value.Date);
                    updateCmd.Parameters.AddWithValue("@JobID", jobId);
                    updateCmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Job updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadJobs(); // Refresh DataGridView
                        ClearInputs();
                        dataGridViewJobs.ClearSelection();
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No job found or you don't have permission to edit this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete selected job
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobId.Text) || !int.TryParse(txtJobId.Text, out int jobId))
            {
                MessageBox.Show("Please enter a valid Job ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Check status before deleting
                    string checkQuery = "SELECT Status FROM jobs WHERE JobID = @JobID AND CustomerID = @CustomerID";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@JobID", jobId);
                    checkCmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                    object statusResult = checkCmd.ExecuteScalar();
                    if (statusResult == null)
                    {
                        MessageBox.Show("No job found with the specified Job ID or you don't have permission to delete this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (statusResult.ToString() != "Pending")
                    {
                        MessageBox.Show("Only jobs in 'Pending' status can be deleted.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this job?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM jobs WHERE JobID = @JobID AND CustomerID = @CustomerID";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@JobID", jobId);
                        deleteCmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Job deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadJobs(); // Refresh DataGridView
                            ClearInputs();
                            dataGridViewJobs.ClearSelection();
                            btnEdit.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No job found or you don't have permission to delete this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clear input fields
        private void ClearInputs()
        {
            txtJobId.Text = string.Empty;
            cmbStartLocation.SelectedIndex = -1;
            cmbDestination.SelectedIndex = -1;
            txtDescription.Text = string.Empty;
            dateTimePickerJobs.Value = DateTime.Today;
        }

        // Clear button click event - clears all input fields and resets form state
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            // Clear all input fields
            ClearInputs();

            // Clear DataGridView selection
            dataGridViewJobs.ClearSelection();

            // Disable Edit and Delete buttons since no job is selected
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            // Optional: Show a brief confirmation message
            // MessageBox.Show("All fields have been cleared.", "Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Minimize the form
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Close the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Go back to previous form (modify as needed)
        private void btnBack_Click(object sender, EventArgs e)
        {
            UsersDashboard usersDashboard = new UsersDashboard();
            usersDashboard.Show();
            this.Close(); // Close the registration form
        }
    }
}
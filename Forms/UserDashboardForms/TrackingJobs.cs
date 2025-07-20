using e_Shift.Common;
using e_Shift.Config;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace e_Shift.Forms.UserDashboardForms
{
    public partial class TrackingJobs : Form
    {
        private int customerId;

        public TrackingJobs()
        {
            InitializeComponent();
            dataGridViewJobsTracking.ReadOnly = true;

            // Check if user is logged in
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to access this form.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Get customer ID from session
            this.customerId = SessionManager.CurrentCustomer.CustomerID; // Common property names: Id, CustomerID, CustomerId
            LoadJobData(); // Load job data when the form is initialized
        }

        // Keep the overloaded constructor for backward compatibility if needed
        public TrackingJobs(int customerId)
        {
            InitializeComponent();

            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to access this form.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.customerId = customerId;
            LoadJobData();
        }

        private void LoadJobData()
        {
            try
            {
                // Establish database connection
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();

                    // Query to fetch jobs for the logged-in customer
                    string query = @"
                        SELECT JobNumber, StartLocation, Destination, Status, CreatedAt, UpdatedAt, Description, PreferredDate
                        FROM jobs
                        WHERE CustomerID = @CustomerID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        // Use DataTable to store query results
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        // Bind the DataTable to the DataGridView
                        dataGridViewJobsTracking.DataSource = dt;

                        // Optional: Customize DataGridView columns for better display
                        dataGridViewJobsTracking.Columns["JobNumber"].HeaderText = "Job Number";
                        dataGridViewJobsTracking.Columns["StartLocation"].HeaderText = "Start Location";
                        dataGridViewJobsTracking.Columns["Destination"].HeaderText = "Destination";
                        dataGridViewJobsTracking.Columns["Status"].HeaderText = "Status";
                        dataGridViewJobsTracking.Columns["CreatedAt"].HeaderText = "Created At";
                        dataGridViewJobsTracking.Columns["UpdatedAt"].HeaderText = "Updated At";
                        dataGridViewJobsTracking.Columns["Description"].HeaderText = "Description";
                        dataGridViewJobsTracking.Columns["PreferredDate"].HeaderText = "Preferred Date";

                        // Adjust column widths
                        dataGridViewJobsTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to the previous form (e.g., Customer Dashboard)
            UsersDashboard dashboard = new UsersDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
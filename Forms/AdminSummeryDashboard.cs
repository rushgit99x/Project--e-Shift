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
using e_Shift.Config;

namespace e_Shift.Forms
{
    public partial class AdminSummeryDashboard : Form
    {
        public AdminSummeryDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Load all dashboard statistics
                lblNewJobs.Text = GetNewJobsCount().ToString();
                lblActiveJobs.Text = GetActiveJobsCount().ToString();
                lblCompletedJobs.Text = GetCompletedJobsCount().ToString();
                lblTotalCustomers.Text = GetTotalCustomersCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNewJobsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM jobs WHERE Status = 'Pending'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving new jobs count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        private int GetActiveJobsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM jobs WHERE Status IN ('Accepted', 'In_Progress')";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving active jobs count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        private int GetCompletedJobsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM jobs WHERE Status = 'Completed'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving completed jobs count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        private int GetTotalCustomersCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM customers";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving total customers count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        // Method to refresh dashboard data (can be called when needed)
        public void RefreshDashboardData()
        {
            LoadDashboardData();
        }

        // Additional methods for more detailed statistics
        private int GetAvailableDriversCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM drivers WHERE Status = 'Available'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving available drivers count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        private int GetAvailableLorriesCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM lorries WHERE Status = 'Available'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving available lorries count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        private int GetAvailableContainersCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM containers WHERE Status = 'Available'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving available containers count: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        // Event handlers for label clicks (you can add navigation or detailed views here)
        private void lblNewJobs_Click(object sender, EventArgs e)
        {
            // Navigate to new jobs view or show details
            MessageBox.Show($"New Jobs: {lblNewJobs.Text}", "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblActiveJobs_Click(object sender, EventArgs e)
        {
            // Navigate to active jobs view or show details
            MessageBox.Show($"Active Jobs: {lblActiveJobs.Text}", "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblCompletedJobs_Click(object sender, EventArgs e)
        {
            // Navigate to completed jobs view or show details
            MessageBox.Show($"Completed Jobs: {lblCompletedJobs.Text}", "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblTotalCustomers_Click(object sender, EventArgs e)
        {
            // Navigate to customers view or show details
            MessageBox.Show($"Total Customers: {lblTotalCustomers.Text}", "Customer Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Timer-based auto-refresh (optional)
        private Timer refreshTimer;

        private void InitializeAutoRefresh()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 30000; // Refresh every 30 seconds
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        // Form closing event to dispose timer
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            refreshTimer?.Stop();
            refreshTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
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
    public partial class UserNotifications : Form
    {
        private DataTable notificationsDataTable;

        public UserNotifications()
        {
            InitializeComponent();
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            try
            {
                if (!SessionManager.IsLoggedIn)
                {
                    MessageBox.Show("Please log in to view notifications.", "Authentication Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            NotificationID,
                            Message,
                            CreatedAt
                        FROM notifications 
                        WHERE RecipientID = @CustomerID 
                        AND RecipientType = 'Customer'
                        ORDER BY CreatedAt DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            notificationsDataTable = new DataTable();
                            adapter.Fill(notificationsDataTable);

                            // Update the DataGridView on the UI thread
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() => {
                                    dataGridViewUserNotifications.DataSource = notificationsDataTable;
                                    FormatDataGridView();
                                }));
                            }
                            else
                            {
                                dataGridViewUserNotifications.DataSource = notificationsDataTable;
                                FormatDataGridView();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridViewUserNotifications.Columns.Count > 0)
            {
                // Hide the ID column
                dataGridViewUserNotifications.Columns["NotificationID"].Visible = false;

                // Set column headers
                dataGridViewUserNotifications.Columns["Message"].HeaderText = "Message";
                dataGridViewUserNotifications.Columns["CreatedAt"].HeaderText = "Date & Time";

                // Set column widths
                dataGridViewUserNotifications.Columns["Message"].Width = 600;
                dataGridViewUserNotifications.Columns["CreatedAt"].Width = 150;

                // Set auto size mode for message column
                dataGridViewUserNotifications.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Format the datetime column
                dataGridViewUserNotifications.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                // Set row height for better readability
                dataGridViewUserNotifications.RowTemplate.Height = 35;

                // Enable word wrap for message column
                dataGridViewUserNotifications.Columns["Message"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // Set alternating row colors
                dataGridViewUserNotifications.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                // Set selection mode
                dataGridViewUserNotifications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewUserNotifications.MultiSelect = false;

                // Make the grid read-only
                dataGridViewUserNotifications.ReadOnly = true;
                dataGridViewUserNotifications.AllowUserToAddRows = false;
                dataGridViewUserNotifications.AllowUserToDeleteRows = false;
            }
        }

        private void MarkAsRead(int notificationId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();

                    string query = "UPDATE notifications SET Status = 'Sent' WHERE NotificationID = @NotificationID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NotificationID", notificationId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking notification as read: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteNotification(int notificationId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM notifications 
                                   WHERE NotificationID = @NotificationID 
                                   AND RecipientID = @CustomerID 
                                   AND RecipientType = 'Customer'";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NotificationID", notificationId);
                        cmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Notification deleted successfully.", "Delete Complete",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Notification not found or could not be deleted.", "Delete Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting notification: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUserNotifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUserNotifications.Rows[e.RowIndex];
                string message = row.Cells["Message"].Value?.ToString() ?? "";
                string createdAt = row.Cells["CreatedAt"].Value?.ToString() ?? "";
                int notificationId = Convert.ToInt32(row.Cells["NotificationID"].Value);

                string fullMessage = $"Message: {message}\n\n" +
                                   $"Date & Time: {createdAt}";

                MessageBox.Show(fullMessage, "Notification Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all notifications?",
                "Confirm Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
                    {
                        connection.Open();

                        string query = @"DELETE FROM notifications 
                                       WHERE RecipientID = @CustomerID 
                                       AND RecipientType = 'Customer'";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", SessionManager.CurrentCustomer.CustomerID);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            MessageBox.Show($"{rowsAffected} notifications cleared successfully.",
                                "Clear Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadNotifications();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing notifications: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewUserNotifications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a notification to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected notification
            DataGridViewRow selectedRow = dataGridViewUserNotifications.SelectedRows[0];
            int notificationId = Convert.ToInt32(selectedRow.Cells["NotificationID"].Value);
            string message = selectedRow.Cells["Message"].Value?.ToString() ?? "";

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this notification?\n\n" +
                $"Message: {(message.Length > 50 ? message.Substring(0, 50) + "..." : message)}",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteNotification(notificationId);
                LoadNotifications(); // Refresh the grid after deletion
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
            this.Close();
        }

        private void UserNotifications_Load(object sender, EventArgs e)
        {
            // Set form properties
            this.Text = "My Notifications";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Check if user is logged in
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Please log in to view notifications.", "Authentication Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Display current user info (optional)
            if (SessionManager.CurrentCustomer != null)
            {
                this.Text = $"Notifications - {SessionManager.CurrentCustomer.FirstName} {SessionManager.CurrentCustomer.LastName}";
            }
        }

        private void dataGridViewUserNotifications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Additional formatting if needed for Message column
            if (dataGridViewUserNotifications.Columns[e.ColumnIndex].Name == "Message")
            {
                if (e.Value != null)
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }
            }
        }
    }
}
// UsersDashboard.cs
using e_Shift.Common;
using e_Shift.Forms.UserDashboardForms;
using e_Shift.Models;
using System;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class UsersDashboard : Form
    {
        public UsersDashboard()
        {
            InitializeComponent();
            CheckSession();
        }

        private void CheckSession()
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("No user is logged in. Please log in first.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            // Optionally, display user information (e.g., in a label)
            lblWelcome.Text = $"Welcome, {SessionManager.CurrentCustomer.FirstName}!";
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Session expired. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            UserJob userJobs = new UserJob();
            userJobs.Show();
            this.Hide();
        }

        // Add a logout button handler
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Session expired. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            UserSettings userSettings = new UserSettings();
            userSettings.Show();
            this.Hide();

        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Session expired. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            UserContactUs userContactUs = new UserContactUs();
            userContactUs.Show();
            this.Hide();
        }

        private void btnTracking_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Session expired. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            TrackingJobs trackingJobs = new TrackingJobs();
            trackingJobs.Show();
            this.Hide();

        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Session expired. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                return;
            }

            UserNotifications usernotifications = new UserNotifications();
            usernotifications.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the application
        }
    }
}
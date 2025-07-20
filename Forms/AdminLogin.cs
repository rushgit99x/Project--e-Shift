using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using e_Shift.Repository.Services;
using System;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class AdminLogin : Form
    {
        private readonly IAdminService _adminService;

        public AdminLogin()
        {
            InitializeComponent();
            _adminService = new AdminService(new AdminRepository());
            // Manually attach the CheckedChanged event
            if (btnShowPassword != null)
            {
                btnShowPassword.CheckedChanged += btnShowPassword_CheckedChanged;
            }
            // Trigger initial state on load
            btnShowPassword_CheckedChanged(this, EventArgs.Empty);
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            // Optional: Additional initialization if needed
            btnShowPassword_CheckedChanged(this, EventArgs.Empty); // Ensure initial state on load
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Admin admin = await _adminService.LoginAdminAsync(txtUsername.Text, txtPassword.Text);
                if (admin != null)
                {
                    MessageBox.Show($"Login successful! Welcome, {admin.FullName}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to Admin Dashboard (assuming you have an AdminDashboard form)
                    AdminDashboard dashboard = new AdminDashboard();
                    dashboard.Show();
                    this.Hide();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (btnShowPassword != null && txtPassword != null) // Safety check
            {
                if (btnShowPassword.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false; // Show password as plain text
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true; // Mask password with asterisks
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the application
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimize the application
        }

        private void lblBackToUserLogin_Click(object sender, EventArgs e)
        {
            LoginForm userLogin = new LoginForm();
            userLogin.Show();
            this.Hide();
        }
    }
}
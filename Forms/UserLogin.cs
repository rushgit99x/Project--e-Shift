using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Common; // Add this for SessionManager
using e_Shift.Forms;
using e_Shift.Models;
using e_Shift.Repository.Services;
using System;
using System.Windows.Forms;

namespace e_Shift
{
    public partial class LoginForm : Form
    {
        private readonly ICustomerService _customerService;

        public LoginForm()
        {
            InitializeComponent();
            _customerService = new CustomerService(new CustomerRepository());
            btnShowPassword_CheckedChanged(this, EventArgs.Empty);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = await _customerService.LoginCustomerAsync(txtEmail.Text, txtPassword.Text);
                if (customer != null)
                {
                    // Store the customer in the session
                    SessionManager.CurrentCustomer = customer;

                    MessageBox.Show($"Login successful! Welcome, your Customer Number is: {customer.CustomerNumber}",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to UserDashboard
                    UsersDashboard dashboard = new UsersDashboard();
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

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            UserRegister registerForm = new UserRegister();
            registerForm.Show();
            this.Hide();
        }

        private void lblAdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLoginForm = new AdminLogin();
            adminLoginForm.Show();
            this.Hide();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void btnShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !btnShowPassword.Checked; // Simplified logic
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the application
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimize the application
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.FormBorderStyle = FormBorderStyle.Sizable;
            //}
            //else
            //{
            //    this.FormBorderStyle = FormBorderStyle.Sizable;
            //    this.WindowState = FormWindowState.Maximized;
            //}
        }
    }
}
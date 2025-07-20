using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Services;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class AdminRegister : Form
    {
        private readonly IAdminService _adminService;

        public AdminRegister()
        {
            InitializeComponent();
            _adminService = new AdminService(new AdminRepository());
            btnShowPassword_CheckedChanged(this, EventArgs.Empty);
        }

        private async void btnRegister_Click_1(object sender, EventArgs e)
        {
            try
            {
                Admin registeredAdmin = await _adminService.RegisterAdminAsync(txtUsername.Text, txtEmail.Text, txtPassword.Text);
                if (registeredAdmin != null)
                {
                    // Send notification email
                    SendRegistrationEmail(registeredAdmin);

                    MessageBox.Show($"Registration successful! Admin ID: {registeredAdmin.AdminID}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields
                    txtUsername.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";

                    // Optionally close the form
                    //this.Close();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Display the inner exception if available
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("An error occurred: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendRegistrationEmail(Admin admin)
        {
            try
            {
                string fromEmail = EmailConfig.SenderEmail;
                string fromPassword = EmailConfig.SenderPassword;
                string toEmail = admin.Email;

                if (string.IsNullOrWhiteSpace(toEmail) || !toEmail.Contains("@") || !toEmail.Contains("."))
                {
                    throw new ArgumentException("Invalid email address for notification.");
                }

                string subject = "Welcome to e-Shift - Admin Registration Successful";
                string body = $@"
                Dear {admin.FullName},

                Thank you for registering as an admin with e-Shift! Your account details are as follows:

                Admin ID: {admin.AdminID}
                Username: {admin.Username}
                Email: {admin.Email}
                Registration Date: {DateTime.Now}

                Please keep this information secure. If you have any questions, feel free to contact us.

                Best regards,
                The e-Shift Team";

                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
                mail.IsBodyHtml = false;

                SmtpClient smtpClient = new SmtpClient(EmailConfig.SmtpHost)
                {
                    Port = EmailConfig.SmtpPort,
                    Credentials = new System.Net.NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                    Timeout = 10000
                };

                smtpClient.Send(mail);
            }
            catch (SmtpException ex)
            {
                string errorMessage = $"SMTP Error sending to {admin.Email} at {DateTime.Now}: {ex.Message}";
                System.IO.File.AppendAllText("error.log", errorMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Failed to send registration email to {admin.Email} at {DateTime.Now}: {ex.Message}";
                System.IO.File.AppendAllText("error.log", errorMessage + Environment.NewLine);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnShowPassword_CheckedChanged(object sender, EventArgs e)
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblBackToAdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }
    }
}
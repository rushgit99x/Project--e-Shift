using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Services;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class UserRegister : Form
    {
        private readonly ICustomerService _customerService;

        public UserRegister()
        {
            InitializeComponent();
            _customerService = new CustomerService(new CustomerRepository());
            btnShowPassword_CheckedChanged(this, EventArgs.Empty);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Customer registeredCustomer = await _customerService.RegisterCustomerAsync(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text);
                if (registeredCustomer != null)
                {
                    // Send registration confirmation email
                    await SendRegistrationEmailAsync(registeredCustomer);

                    MessageBox.Show($"Registration successful! Your Customer Number is: {registeredCustomer.CustomerNumber}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";

                    // Navigate to login page
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close(); // Close the registration form
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

        private async Task SendRegistrationEmailAsync(Customer customer)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(EmailConfig.SmtpHost, EmailConfig.SmtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential(EmailConfig.SenderEmail, EmailConfig.SenderPassword);

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(EmailConfig.SenderEmail, EmailConfig.SenderDisplayName),
                        Subject = "Welcome to e-Shift!",
                        Body = $@"Dear {customer.FirstName} {customer.LastName},

                            Thank you for registering with e-Shift! Your account has been successfully created.
                            Your Customer Number is: {customer.CustomerNumber}

                            You can now log in to your account using your email ({customer.Email}) and password.

                            Best regards,
                            The e-Shift Team",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(customer.Email);

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (SmtpException ex)
            {
                throw new Exception("Failed to send registration email: " + ex.Message, ex);
            }
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            LoginForm userLogin = new LoginForm();
            userLogin.Show();
            this.Close(); // Close the registration form
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the application
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimize the application
        }
    }
}
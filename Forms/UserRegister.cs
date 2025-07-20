using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Services;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
                // Validate all input fields
                if (!ValidateInput())
                {
                    return; // Stop if validation fails
                }

                Customer registeredCustomer = await _customerService.RegisterCustomerAsync(
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtEmail.Text.Trim().ToLower(),
                    txtPassword.Text);

                if (registeredCustomer != null)
                {
                    // Send registration confirmation email
                    await SendRegistrationEmailAsync(registeredCustomer);

                    MessageBox.Show($"Registration successful! Your Customer Number is: {registeredCustomer.CustomerNumber}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields
                    ClearFields();

                    // Navigate to login page
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close(); // Close the registration form
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Reset any previous error styling (optional - if you have visual error indicators)
            ResetFieldStyles();

            string errorMessage = "";

            // First Name validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorMessage += "• First name is required.\n";
                HighlightErrorField(txtFirstName);
            }
            else if (txtFirstName.Text.Trim().Length < 2)
            {
                errorMessage += "• First name must be at least 2 characters long.\n";
                HighlightErrorField(txtFirstName);
            }
            else if (txtFirstName.Text.Trim().Length > 50)
            {
                errorMessage += "• First name cannot exceed 50 characters.\n";
                HighlightErrorField(txtFirstName);
            }
            else if (!IsValidName(txtFirstName.Text.Trim()))
            {
                errorMessage += "• First name contains invalid characters. Only letters, spaces, hyphens, and apostrophes are allowed.\n";
                HighlightErrorField(txtFirstName);
            }

            // Last Name validation
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessage += "• Last name is required.\n";
                HighlightErrorField(txtLastName);
            }
            else if (txtLastName.Text.Trim().Length < 2)
            {
                errorMessage += "• Last name must be at least 2 characters long.\n";
                HighlightErrorField(txtLastName);
            }
            else if (txtLastName.Text.Trim().Length > 50)
            {
                errorMessage += "• Last name cannot exceed 50 characters.\n";
                HighlightErrorField(txtLastName);
            }
            else if (!IsValidName(txtLastName.Text.Trim()))
            {
                errorMessage += "• Last name contains invalid characters. Only letters, spaces, hyphens, and apostrophes are allowed.\n";
                HighlightErrorField(txtLastName);
            }

            // Email validation
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessage += "• Email address is required.\n";
                HighlightErrorField(txtEmail);
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                errorMessage += "• Please enter a valid email address.\n";
                HighlightErrorField(txtEmail);
            }
            else if (txtEmail.Text.Trim().Length > 254) // RFC 5321 limit
            {
                errorMessage += "• Email address is too long (maximum 254 characters).\n";
                HighlightErrorField(txtEmail);
            }

            // Password validation
            var passwordValidation = ValidatePassword(txtPassword.Text);
            if (!passwordValidation.IsValid)
            {
                errorMessage += passwordValidation.ErrorMessage;
                HighlightErrorField(txtPassword);
            }

            // Show validation errors if any
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Please correct the following errors:\n\n" + errorMessage,
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private (bool IsValid, string ErrorMessage) ValidatePassword(string password)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "• Password is required.\n");
            }

            if (password.Length < 8)
            {
                errorMessage += "• Password must be at least 8 characters long.\n";
            }

            if (password.Length > 128)
            {
                errorMessage += "• Password cannot exceed 128 characters.\n";
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                errorMessage += "• Password must contain at least one uppercase letter.\n";
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                errorMessage += "• Password must contain at least one lowercase letter.\n";
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                errorMessage += "• Password must contain at least one digit.\n";
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
            {
                errorMessage += "• Password must contain at least one special character (!@#$%^&*()_+-=[]{}|;':\"\\,.<>?/).\n";
            }

            // Check for common weak patterns
            if (ContainsCommonWeakPatterns(password))
            {
                errorMessage += "• Password contains common patterns that make it weak. Please choose a more secure password.\n";
            }

            // Check if password contains whitespace
            if (password.Contains(" "))
            {
                errorMessage += "• Password cannot contain spaces.\n";
            }

            return (string.IsNullOrEmpty(errorMessage), errorMessage);
        }

        private bool ContainsCommonWeakPatterns(string password)
        {
            string lowerPassword = password.ToLower();

            // Check for sequential characters
            if (Regex.IsMatch(lowerPassword, @"(abc|bcd|cde|def|efg|fgh|ghi|hij|ijk|jkl|klm|lmn|mno|nop|opq|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz)") ||
                Regex.IsMatch(password, @"(123|234|345|456|567|678|789|890)"))
            {
                return true;
            }

            // Check for repeated characters (3 or more in a row)
            if (Regex.IsMatch(password, @"(.)\1{2,}"))
            {
                return true;
            }

            // Check for common weak passwords
            string[] commonPasswords = { "password", "123456", "qwerty", "admin", "letmein", "welcome", "monkey" };
            foreach (string common in commonPasswords)
            {
                if (lowerPassword.Contains(common))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // Use MailAddress to validate email format
                var addr = new MailAddress(email);
                return addr.Address == email &&
                       Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidName(string name)
        {
            // Allow letters, spaces, hyphens, and apostrophes
            return Regex.IsMatch(name, @"^[a-zA-Z\s\-']+$");
        }

        private void HighlightErrorField(Control control)
        {
            // Visual feedback for validation errors
            control.BackColor = System.Drawing.Color.FromArgb(255, 230, 230); // Light red background
        }

        private void ResetFieldStyles()
        {
            // Reset all text boxes to default appearance
            txtFirstName.BackColor = System.Drawing.SystemColors.Window;
            txtLastName.BackColor = System.Drawing.SystemColors.Window;
            txtEmail.BackColor = System.Drawing.SystemColors.Window;
            txtPassword.BackColor = System.Drawing.SystemColors.Window;
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            ResetFieldStyles();
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

        // Event handlers for real-time validation feedback (optional)
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.BackColor != System.Drawing.SystemColors.Window)
            {
                txtFirstName.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.BackColor != System.Drawing.SystemColors.Window)
            {
                txtLastName.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.BackColor != System.Drawing.SystemColors.Window)
            {
                txtEmail.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.BackColor != System.Drawing.SystemColors.Window)
            {
                txtPassword.BackColor = System.Drawing.SystemColors.Window;
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

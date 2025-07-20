using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using e_Shift.Config;

namespace e_Shift.Forms.UserDashboardForms
{
    public partial class UserContactUs : Form
    {
        private const string ADMIN_EMAIL = "rvdmsi694@gmail.com";

        public UserContactUs()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all text boxes
            txtCustomerId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtSubject.Clear();
            txtMessage.Clear();

            // Set focus to first text box
            txtCustomerId.Focus();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                // Disable the button to prevent multiple clicks
                btnSubmit.Enabled = false;
                btnSubmit.Text = "Sending...";

                // Send email to admin
                await SendEmailToAdmin();

                // Show success message
                MessageBox.Show("Your message has been sent successfully! We will get back to you soon.",
                              "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form after successful submission
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send message. Error: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable the button
                btnSubmit.Enabled = true;
                btnSubmit.Text = "Send Message";
            }
        }

        private bool ValidateInputs()
        {
            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("Please enter your Customer ID.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Please enter a subject.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubject.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter your message.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessage.Focus();
                return false;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async Task SendEmailToAdmin()
        {
            using (var client = new SmtpClient(EmailConfig.SmtpHost, EmailConfig.SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(EmailConfig.SenderEmail, EmailConfig.SenderPassword);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.SenderEmail, EmailConfig.SenderDisplayName),
                    Subject = $"Contact Us - {txtSubject.Text}",
                    Body = CreateEmailBody(),
                    IsBodyHtml = true
                };

                // Send to admin email
                mailMessage.To.Add(ADMIN_EMAIL);

                // Add reply-to header with customer's email
                mailMessage.ReplyToList.Add(new MailAddress(txtEmail.Text, txtName.Text));

                await client.SendMailAsync(mailMessage);
            }
        }

        private string CreateEmailBody()
        {
            var emailBody = new StringBuilder();
            emailBody.AppendLine("<html><body>");
            emailBody.AppendLine("<h2>New Contact Us Message</h2>");
            emailBody.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse: collapse;'>");
            emailBody.AppendLine($"<tr><td><strong>Customer ID:</strong></td><td>{txtCustomerId.Text}</td></tr>");
            emailBody.AppendLine($"<tr><td><strong>Name:</strong></td><td>{txtName.Text}</td></tr>");
            emailBody.AppendLine($"<tr><td><strong>Email:</strong></td><td>{txtEmail.Text}</td></tr>");
            emailBody.AppendLine($"<tr><td><strong>Subject:</strong></td><td>{txtSubject.Text}</td></tr>");
            emailBody.AppendLine($"<tr><td><strong>Message:</strong></td><td>{txtMessage.Text.Replace(Environment.NewLine, "<br/>")}</td></tr>");
            emailBody.AppendLine($"<tr><td><strong>Date/Time:</strong></td><td>{DateTime.Now:yyyy-MM-dd HH:mm:ss}</td></tr>");
            emailBody.AppendLine("</table>");
            emailBody.AppendLine("</body></html>");

            return emailBody.ToString();
        }

        private void ClearForm()
        {
            txtCustomerId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtSubject.Clear();
            txtMessage.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
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
            // Close the application
            Application.Exit();
        }
    }
}
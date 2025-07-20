using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Repository.Interface;
using e_Shift.Repository.Service;
using e_Shift.Repository.Services;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using e_Shift.Config; // Ensure this namespace is included for DBConnection

namespace e_Shift.Forms
{
    public partial class AdminDashboard : Form
    {
        // Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        // Constructor
        public AdminDashboard()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            // Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            // Load dashboard data on form initialization
            LoadDashboardData();
            // Initialize auto-refresh timer
            InitializeAutoRefresh();
        }

        // Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        // Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
            LoadDashboardData(); // Refresh data when resetting to home
        }

        // Database methods from AdminSummeryDashboard
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

        // Timer-based auto-refresh
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

        // Event handlers for label clicks
        private void lblNewJobs_Click(object sender, EventArgs e)
        {
            // Show details or navigate to new jobs view
            ActivateButton(btnJobs, RGBColors.color2); // Highlight Jobs button
            OpenChildForm(new AdminJobs()); // Open AdminJobs form for detailed view
            // Optional: Show a message box with the count
            MessageBox.Show($"New Jobs: {lblNewJobs.Text}", "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblActiveJobs_Click(object sender, EventArgs e)
        {
            // Show details or navigate to active jobs view
            ActivateButton(btnJobs, RGBColors.color2); // Highlight Jobs button
            OpenChildForm(new AdminJobs()); // Open AdminJobs form for detailed view
            MessageBox.Show($"Active Jobs: {lblActiveJobs.Text}", "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblCompletedJobs_Click(object sender, EventArgs e)
        {
            // Show details or navigate to completed jobs view
            ActivateButton(btnJobs, RGBColors.color2); // Highlight Jobs button
            OpenChildForm(new AdminJobs()); // Open AdminJobs form for detailed view
            MessageBox.Show($"Completed Jobs: {lblCompletedJobs.Text}", "Job Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblTotalCustomers_Click(object sender, EventArgs e)
        {
            // Show details or navigate to customers view
            ActivateButton(btnUserManagement, RGBColors.color4); // Highlight User Management button
            IAdminManageRepository adminRepository = new AdminManageRepository();
            IAdminManageService adminService = new AdminManageService(adminRepository);
            OpenChildForm(new AdminUserManagement(adminService)); // Open AdminUserManagement form
            MessageBox.Show($"Total Customers: {lblTotalCustomers.Text}", "Customer Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Events
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            LoadDashboardData(); // Refresh data when dashboard button is clicked
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
                lblTitleChildForm.Text = "Dashboard";
            }
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new AdminJobs());
        }

        private void btnLoadManagement_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            ILoadRepository loadRepository = new LoadRepository();
            ILoadService loadService = new LoadService(loadRepository);
            OpenChildForm(new AdminLoadManagement(loadService));
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            IAdminManageRepository adminRepository = new AdminManageRepository();
            IAdminManageService adminService = new AdminManageService(adminRepository);
            OpenChildForm(new AdminUserManagement(adminService));
        }

        private void btnTransportUnits_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new AdminTransportUnits());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            IProductRepository productRepository = new ProductRepository();
            IProductService productService = new ProductService(productRepository);
            OpenChildForm(new AdminProducts(productService));
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IReportRepository reportRepository = new ReportRepository();
            IReportService reportService = new ReportService(reportRepository);
            OpenChildForm(new AdminReports(reportService));
        }
        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color6);
            //IProductRepository productRepository = new ProductRepository();
            //IProductService productService = new ProductService(productRepository);
            //OpenChildForm(new AdminProducts(productService));
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new AdminCustomerManagement());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        // Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {
        }

        
    }
}
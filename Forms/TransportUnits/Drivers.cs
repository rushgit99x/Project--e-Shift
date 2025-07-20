using System;
using System.Drawing;
using System.Windows.Forms;
using e_Shift.Business.Interface;
using e_Shift.Models;

namespace e_Shift.Forms.TransportUnits
{
    public partial class Drivers : Form
    {
        private readonly IDriverService _driverService;

        public Drivers(IDriverService driverService)
        {
            InitializeComponent();
            _driverService = driverService;
            InitializeComboBox();
            LoadDriverData();
            txtDriverId.Enabled = false; // Disable txtDriverId to prevent editing
            txtDriverId.ReadOnly = true; // Reinforce read-only status
            txtDriverId.BackColor = Color.LightGray; // Visual cue for non-editable field
            dataGridViewDrivers.ReadOnly = true; // Prevent editing in DataGridView
            dataGridViewDrivers.AllowUserToAddRows = false; // Prevent adding new rows
            dataGridViewDrivers.AllowUserToDeleteRows = false; // Prevent deleting rows via grid
            ConfigureControls();
        }

        private void ConfigureControls()
        {
            // Set ComboBoxes to DropDownList style to prevent manual entry
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeComboBox()
        {
            cmbStatus.Items.AddRange(new object[] { "Select the status", "Available", "Assigned", "Inactive" });
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadDriverData()
        {
            try
            {
                var drivers = _driverService.GetAllDrivers();
                dataGridViewDrivers.DataSource = drivers;

                // Configure DataGridView columns
                if (dataGridViewDrivers.Columns.Contains("DriverID"))
                    dataGridViewDrivers.Columns["DriverID"].HeaderText = "ID";
                if (dataGridViewDrivers.Columns.Contains("FirstName"))
                    dataGridViewDrivers.Columns["FirstName"].HeaderText = "First Name";
                if (dataGridViewDrivers.Columns.Contains("LastName"))
                    dataGridViewDrivers.Columns["LastName"].HeaderText = "Last Name";
                if (dataGridViewDrivers.Columns.Contains("LicenseNumber"))
                    dataGridViewDrivers.Columns["LicenseNumber"].HeaderText = "License Number";
                if (dataGridViewDrivers.Columns.Contains("Phone"))
                    dataGridViewDrivers.Columns["Phone"].HeaderText = "Phone";
                if (dataGridViewDrivers.Columns.Contains("Status"))
                    dataGridViewDrivers.Columns["Status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var driver = new Driver
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                LicenseNumber = txtLicenseNo.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_driverService.ValidateDriver(driver, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _driverService.AddDriver(driver);
                MessageBox.Show("Driver registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadDriverData();
            }
            catch (Exception ex) when (ex.Message.Contains("This license number is already registered"))
            {
                MessageBox.Show("This license number is already registered. Please use a unique license number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering driver: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDrivers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this driver?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int driverId = (int)dataGridViewDrivers.SelectedRows[0].Cells["DriverID"].Value;
                    _driverService.DeleteDriver(driverId); // Corrected: Removed assignment to 'bool result'
                    MessageBox.Show("Driver deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDriverData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting driver: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDrivers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var driver = new Driver
            {
                DriverID = (int)dataGridViewDrivers.SelectedRows[0].Cells["DriverID"].Value,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                LicenseNumber = txtLicenseNo.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_driverService.ValidateDriver(driver, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _driverService.UpdateDriver(driver); // Corrected: Removed assignment to 'bool result'
                MessageBox.Show("Driver updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadDriverData();
            }
            catch (Exception ex) when (ex.Message.Contains("This license number is already registered"))
            {
                MessageBox.Show("This license number is already registered. Please use a unique license number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating driver: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDrivers.Rows[e.RowIndex];
                txtDriverId.Text = row.Cells["DriverID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtLicenseNo.Text = row.Cells["LicenseNumber"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Select the status";
            }
        }

        private void ClearInputs()
        {
            txtDriverId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtLicenseNo.Text = "";
            txtPhone.Text = "";
            cmbStatus.SelectedIndex = 0;
        }
    }
}
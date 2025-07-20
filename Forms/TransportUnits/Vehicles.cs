using System;
using System.Drawing;
using System.Windows.Forms;
using e_Shift.Business.Interface;
using e_Shift.Models;

namespace e_Shift.Forms.TransportUnits
{
    public partial class Vehicles : Form
    {
        private readonly ILorryService _lorryService;

        public Vehicles(ILorryService lorryService)
        {
            InitializeComponent();
            _lorryService = lorryService;
            InitializeComboBoxes();
            LoadLorryData();
            txtLorryID.Enabled = false; // Disable txtLorryID to prevent editing
            txtLorryID.ReadOnly = true; // Reinforce read-only status
            txtLorryID.BackColor = Color.LightGray; // Visual cue for non-editable field
            dataGridViewVehicles.ReadOnly = true; // Prevent editing in DataGridView
            dataGridViewVehicles.AllowUserToAddRows = false; // Prevent adding new rows
            dataGridViewVehicles.AllowUserToDeleteRows = false; // Prevent deleting rows via grid
            ConfigureControls();
        }
        private void ConfigureControls()
        {
            // Set ComboBoxes to DropDownList style to prevent manual entry
            cmbCapacity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void InitializeComboBoxes()
        {
            // Initialize Status combobox
            cmbStatus.Items.AddRange(new object[] { "Select the status", "Available", "In_Use", "Maintenance" });
            cmbStatus.SelectedIndex = 0;

            // Initialize Capacity combobox with common lorry capacities (in tons)
            cmbCapacity.Items.AddRange(new object[] { "Select capacity", "5.00", "10.00", "15.00", "20.00", "25.00" });
            cmbCapacity.SelectedIndex = 0;
        }

        private void LoadLorryData()
        {
            try
            {
                var lorries = _lorryService.GetAllLorries();
                dataGridViewVehicles.DataSource = lorries;

                // Configure DataGridView columns
                if (dataGridViewVehicles.Columns.Contains("LorryID"))
                    dataGridViewVehicles.Columns["LorryID"].HeaderText = "ID";
                if (dataGridViewVehicles.Columns.Contains("LicensePlate"))
                    dataGridViewVehicles.Columns["LicensePlate"].HeaderText = "License Plate";
                if (dataGridViewVehicles.Columns.Contains("Model"))
                    dataGridViewVehicles.Columns["Model"].HeaderText = "Model";
                if (dataGridViewVehicles.Columns.Contains("Capacity"))
                    dataGridViewVehicles.Columns["Capacity"].HeaderText = "Capacity (tons)";
                if (dataGridViewVehicles.Columns.Contains("Status"))
                    dataGridViewVehicles.Columns["Status"].HeaderText = "Status";
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
            var lorry = new Lorry
            {
                LicensePlate = txtLicensePlate.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Capacity = cmbCapacity.SelectedIndex > 0 ? decimal.Parse(cmbCapacity.SelectedItem.ToString()) : 0,
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_lorryService.ValidateLorry(lorry, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _lorryService.AddLorry(lorry);
                MessageBox.Show("Lorry registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadLorryData();
            }
            catch (Exception ex) when (ex.Message.Contains("This license plate is already registered"))
            {
                MessageBox.Show("This license plate is already registered. Please use a unique license plate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering lorry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewVehicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a lorry to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this lorry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int lorryId = (int)dataGridViewVehicles.SelectedRows[0].Cells["LorryID"].Value;
                    bool result = _lorryService.DeleteLorry(lorryId);
                    if (result)
                    {
                        MessageBox.Show("Lorry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLorryData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete lorry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting lorry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dataGridViewVehicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a lorry to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lorry = new Lorry
            {
                LorryID = (int)dataGridViewVehicles.SelectedRows[0].Cells["LorryID"].Value,
                LicensePlate = txtLicensePlate.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Capacity = cmbCapacity.SelectedIndex > 0 ? decimal.Parse(cmbCapacity.SelectedItem.ToString()) : 0,
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_lorryService.ValidateLorry(lorry, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool result = _lorryService.UpdateLorry(lorry);
                if (result)
                {
                    MessageBox.Show("Lorry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadLorryData();
                }
                else
                {
                    MessageBox.Show("Failed to update lorry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) when (ex.Message.Contains("This license plate is already registered"))
            {
                MessageBox.Show("This license plate is already registered. Please use a unique license plate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating lorry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewVehicles.Rows[e.RowIndex];
                txtLorryID.Text = row.Cells["LorryID"].Value.ToString();
                txtLicensePlate.Text = row.Cells["LicensePlate"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                string capacity = row.Cells["Capacity"].Value.ToString();
                cmbCapacity.SelectedIndex = cmbCapacity.Items.Contains(capacity) ? cmbCapacity.Items.IndexOf(capacity) : 0;
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Select the status";
            }
        }

        private void ClearInputs()
        {
            txtLorryID.Text = "";
            txtLicensePlate.Text = "";
            txtModel.Text = "";
            cmbCapacity.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }
    }
}
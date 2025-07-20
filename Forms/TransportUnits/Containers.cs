using System;
using System.Drawing;
using System.Windows.Forms;
using e_Shift.Business.Interface;
using e_Shift.Models;

namespace e_Shift.Forms.TransportUnits
{
    public partial class Containers : Form
    {
        private readonly IContainerService _containerService;

        public Containers(IContainerService containerService)
        {
            InitializeComponent();
            _containerService = containerService;
            InitializeComboBoxes();
            LoadContainerData();
            txtContainerId.Enabled = false; // Disable txtContainerId to prevent editing
            txtContainerId.ReadOnly = true; // Reinforce read-only status
            txtContainerId.BackColor = Color.LightGray; // Visual cue for non-editable field
            dataGridViewContainer.ReadOnly = true; // Prevent editing in DataGridView
            dataGridViewContainer.AllowUserToAddRows = false; // Prevent adding new rows
            dataGridViewContainer.AllowUserToDeleteRows = false; // Prevent deleting rows via grid
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

            // Initialize Capacity combobox with common container capacities (in tons)
            cmbCapacity.Items.AddRange(new object[] { "Select capacity", "5.00", "10.00", "15.00", "20.00", "25.00" });
            cmbCapacity.SelectedIndex = 0;
        }

        private void LoadContainerData()
        {
            try
            {
                var containers = _containerService.GetAllContainers();
                dataGridViewContainer.DataSource = containers;

                // Configure DataGridView columns
                if (dataGridViewContainer.Columns.Contains("ContainerID"))
                    dataGridViewContainer.Columns["ContainerID"].HeaderText = "ID";
                if (dataGridViewContainer.Columns.Contains("ContainerNumber"))
                    dataGridViewContainer.Columns["ContainerNumber"].HeaderText = "Container Number";
                if (dataGridViewContainer.Columns.Contains("Capacity"))
                    dataGridViewContainer.Columns["Capacity"].HeaderText = "Capacity (tons)";
                if (dataGridViewContainer.Columns.Contains("Status"))
                    dataGridViewContainer.Columns["Status"].HeaderText = "Status";
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
            var container = new Container
            {
                ContainerNumber = txtContainerNo.Text.Trim(),
                Capacity = cmbCapacity.SelectedIndex > 0 ? decimal.Parse(cmbCapacity.SelectedItem.ToString()) : 0,
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_containerService.ValidateContainer(container, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _containerService.AddContainer(container);
                MessageBox.Show("Container registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadContainerData();
            }
            catch (Exception ex) when (ex.Message.Contains("This container number is already registered"))
            {
                MessageBox.Show("This container number is already registered. Please use a unique container number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering container: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewContainer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a container to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this container?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int containerId = (int)dataGridViewContainer.SelectedRows[0].Cells["ContainerID"].Value;
                    _containerService.DeleteContainer(containerId); // Fix: Remove assignment to 'result' since DeleteContainer returns void
                    MessageBox.Show("Container deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContainerData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting container: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dataGridViewContainer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a container to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var container = new Container
            {
                ContainerID = (int)dataGridViewContainer.SelectedRows[0].Cells["ContainerID"].Value,
                ContainerNumber = txtContainerNo.Text.Trim(),
                Capacity = cmbCapacity.SelectedIndex > 0 ? decimal.Parse(cmbCapacity.SelectedItem.ToString()) : 0,
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_containerService.ValidateContainer(container, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _containerService.UpdateContainer(container); // Fix: Remove assignment to 'result' since UpdateContainer returns void
                MessageBox.Show("Container updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadContainerData();
            }
            catch (Exception ex) when (ex.Message.Contains("This container number is already registered"))
            {
                MessageBox.Show("This container number is already registered. Please use a unique container number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating container: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewContainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewContainer.Rows[e.RowIndex];
                txtContainerId.Text = row.Cells["ContainerID"].Value.ToString();
                txtContainerNo.Text = row.Cells["ContainerNumber"].Value.ToString();
                string capacity = row.Cells["Capacity"].Value.ToString();
                cmbCapacity.SelectedIndex = cmbCapacity.Items.Contains(capacity) ? cmbCapacity.Items.IndexOf(capacity) : 0;
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Select the status";
            }
        }

        private void ClearInputs()
        {
            txtContainerId.Text = "";
            txtContainerNo.Text = "";
            cmbCapacity.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }
    }
}
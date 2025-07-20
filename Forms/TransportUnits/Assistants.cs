using System;
using System.Drawing;
using System.Windows.Forms;
using e_Shift.Business.Interface;
using e_Shift.Models;

namespace e_Shift.Forms.TransportUnits
{
    public partial class Assistants : Form
    {
        private readonly IAssistantService _assistantService;

        public Assistants(IAssistantService assistantService)
        {
            InitializeComponent();
            _assistantService = assistantService;
            InitializeComboBox();
            LoadAssistantData();
            ConfigureControls();

            txtAssistantId.Enabled = false; // Disable txtAssistantId to prevent editing
            txtAssistantId.ReadOnly = true; // Reinforce read-only status
            txtAssistantId.BackColor = Color.LightGray; // Visual cue for non-editable field
            dataGridViewAssistants.ReadOnly = true; // Prevent editing in DataGridView
            dataGridViewAssistants.AllowUserToAddRows = false; // Prevent adding new rows
            dataGridViewAssistants.AllowUserToDeleteRows = false; // Prevent deleting rows via grid
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

        private void LoadAssistantData()
        {
            try
            {
                var assistants = _assistantService.GetAllAssistants();
                dataGridViewAssistants.DataSource = assistants;

                // Configure DataGridView columns
                if (dataGridViewAssistants.Columns.Contains("AssistantID"))
                    dataGridViewAssistants.Columns["AssistantID"].HeaderText = "ID";
                if (dataGridViewAssistants.Columns.Contains("FirstName"))
                    dataGridViewAssistants.Columns["FirstName"].HeaderText = "First Name";
                if (dataGridViewAssistants.Columns.Contains("LastName"))
                    dataGridViewAssistants.Columns["LastName"].HeaderText = "Last Name";
                if (dataGridViewAssistants.Columns.Contains("Phone"))
                    dataGridViewAssistants.Columns["Phone"].HeaderText = "Phone";
                if (dataGridViewAssistants.Columns.Contains("Status"))
                    dataGridViewAssistants.Columns["Status"].HeaderText = "Status";
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
            var assistant = new Assistant
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_assistantService.ValidateAssistant(assistant, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _assistantService.AddAssistant(assistant);
                MessageBox.Show("Assistant registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadAssistantData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering assistant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssistants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assistant to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this assistant?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int assistantId = (int)dataGridViewAssistants.SelectedRows[0].Cells["AssistantID"].Value;
                    _assistantService.DeleteAssistant(assistantId); // Corrected: DeleteAssistant returns void, no assignment needed.
                    MessageBox.Show("Assistant deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssistantData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting assistant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dataGridViewAssistants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assistant to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var assistant = new Assistant
            {
                AssistantID = (int)dataGridViewAssistants.SelectedRows[0].Cells["AssistantID"].Value,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Status = cmbStatus.SelectedItem?.ToString()
            };

            if (!_assistantService.ValidateAssistant(assistant, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _assistantService.UpdateAssistant(assistant); // Corrected: UpdateAssistant returns void, no assignment needed.
                MessageBox.Show("Assistant updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadAssistantData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating assistant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewAssistants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAssistants.Rows[e.RowIndex];
                txtAssistantId.Text = row.Cells["AssistantID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Select the status";
            }
        }

        private void pictureBoxDriver_Click(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void ClearInputs()
        {
            txtAssistantId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            cmbStatus.SelectedIndex = 0;
        }
    }
}
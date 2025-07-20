using System;
using System.Collections.Generic;
using System.Windows.Forms;
using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using e_Shift.Repository.Services;

namespace e_Shift.Forms.Jobs
{
    public partial class ApprovedJobs : Form
    {
        private readonly IApprovedJobService _approvedJobService;

        public ApprovedJobs()
        {
            InitializeComponent();

            // Dependency injection setup
            IApprovedJobRepository approvedJobRepository = new ApprovedJobRepository();
            ITransportUnitRepository transportUnitRepository = new TransportUnitRepository();
            ITransportUnitViewRepository transportUnitViewRepository = new TransportUnitViewRepository();
            ILorryRepository lorryRepository = new LorryRepository();
            IDriverRepository driverRepository = new DriverRepository();
            IAssistantRepository assistantRepository = new AssistantRepository();
            IContainerRepository containerRepository = new ContainerRepository();
            INotificationRepository notificationRepository = new NotificationRepository();
            _approvedJobService = new ApprovedJobService(
                approvedJobRepository,
                transportUnitRepository,
                transportUnitViewRepository,
                lorryRepository,
                driverRepository,
                assistantRepository,
                containerRepository,
                notificationRepository);

            LoadComboBoxes();
            LoadApprovedJobs();
            LoadTransportUnits();
            ConfigureControls();
        }
        private void ConfigureControls()
        {
            // Set ComboBoxes to DropDownList style to prevent manual entry
            cmbTransportID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLorryId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDriverId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssistantId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContainerId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load TransportUnitIDs
                var transportUnits = _approvedJobService.GetTransportUnits();
                cmbTransportID.DataSource = transportUnits;
                cmbTransportID.DisplayMember = "TransportUnitID";
                cmbTransportID.ValueMember = "TransportUnitID";
                cmbTransportID.SelectedIndex = -1;

                // Load LorryIDs
                var lorries = _approvedJobService.GetAvailableLorries();
                cmbLorryId.DataSource = lorries;
                cmbLorryId.DisplayMember = "LicensePlate";
                cmbLorryId.ValueMember = "LorryID";
                cmbLorryId.SelectedIndex = -1;

                // Load DriverIDs
                var drivers = _approvedJobService.GetAvailableDrivers();
                cmbDriverId.DataSource = drivers;
                cmbDriverId.DisplayMember = "FullName"; // Add a computed property in Driver model if needed
                cmbDriverId.ValueMember = "DriverID";
                cmbDriverId.SelectedIndex = -1;

                // Load AssistantIDs
                var assistants = _approvedJobService.GetAvailableAssistants();
                cmbAssistantId.DataSource = assistants;
                cmbAssistantId.DisplayMember = "FullName"; // Add a computed property in Assistant model if needed
                cmbAssistantId.ValueMember = "AssistantID";
                cmbAssistantId.SelectedIndex = -1;

                // Load ContainerIDs
                var containers = _approvedJobService.GetAvailableContainers();
                cmbContainerId.DataSource = containers;
                cmbContainerId.DisplayMember = "ContainerNumber";
                cmbContainerId.ValueMember = "ContainerID";
                cmbContainerId.SelectedIndex = -1;

                // Load Status options
                cmbStatus.DataSource = _approvedJobService.GetTransportUnitStatuses();
                cmbStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading comboboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApprovedJobs()
        {
            try
            {
                List<ApprovedJob> jobs = _approvedJobService.GetApprovedJobs();
                dataGridViewApprovedJobs.DataSource = jobs;
                dataGridViewApprovedJobs.ReadOnly = true;
                dataGridViewApprovedJobs.AllowUserToAddRows = false;
                dataGridViewApprovedJobs.AllowUserToDeleteRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading approved jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransportUnits()
        {
            try
            {
                List<TransportUnitView> transportUnits = _approvedJobService.GetTransportUnits();
                dataGridViewTrackingJobs.DataSource = transportUnits;
                dataGridViewTrackingJobs.ReadOnly = true;
                dataGridViewTrackingJobs.AllowUserToAddRows = false;
                dataGridViewTrackingJobs.AllowUserToDeleteRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transport units: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbLorryId.SelectedIndex == -1 || cmbDriverId.SelectedIndex == -1 ||
                cmbAssistantId.SelectedIndex == -1 || cmbContainerId.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TransportUnit transportUnit = new TransportUnit
                {
                    LorryID = (int)cmbLorryId.SelectedValue,
                    DriverID = (int)cmbDriverId.SelectedValue,
                    AssistantID = (int)cmbAssistantId.SelectedValue,
                    ContainerID = (int)cmbContainerId.SelectedValue,
                    Status = cmbStatus.SelectedItem.ToString()
                };

                bool result = _approvedJobService.AssignTransportUnit(transportUnit);
                if (result)
                {
                    MessageBox.Show("Transport unit assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransportUnits();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to assign transport unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTrackingJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transport unit to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int transportUnitId = Convert.ToInt32(dataGridViewTrackingJobs.SelectedRows[0].Cells["TransportUnitID"].Value);
                bool result = _approvedJobService.DeleteTransportUnit(transportUnitId);
                if (result)
                {
                    MessageBox.Show("Transport unit deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransportUnits();
                }
                else
                {
                    MessageBox.Show("Failed to delete transport unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTrackingJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transport unit to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int transportUnitId = Convert.ToInt32(dataGridViewTrackingJobs.SelectedRows[0].Cells["TransportUnitID"].Value);
                TransportUnit transportUnit = new TransportUnit
                {
                    TransportUnitID = transportUnitId,
                    LorryID = (int)cmbLorryId.SelectedValue,
                    DriverID = (int)cmbDriverId.SelectedValue,
                    AssistantID = (int)cmbAssistantId.SelectedValue,
                    ContainerID = (int)cmbContainerId.SelectedValue,
                    Status = cmbStatus.SelectedItem.ToString()
                };

                bool result = _approvedJobService.UpdateTransportUnit(transportUnit);
                if (result)
                {
                    MessageBox.Show("Transport unit updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransportUnits();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to update transport unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompleteJob_Click(object sender, EventArgs e)
        {
            if (dataGridViewApprovedJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int jobId = Convert.ToInt32(dataGridViewApprovedJobs.SelectedRows[0].Cells["JobID"].Value);
                string jobNumber = dataGridViewApprovedJobs.SelectedRows[0].Cells["JobNumber"].Value.ToString();
                string customerFirstName = dataGridViewApprovedJobs.SelectedRows[0].Cells["CustomerFirstName"].Value.ToString();
                string customerLastName = dataGridViewApprovedJobs.SelectedRows[0].Cells["CustomerLastName"].Value.ToString();
                string startLocation = dataGridViewApprovedJobs.SelectedRows[0].Cells["StartLocation"].Value.ToString();
                string destination = dataGridViewApprovedJobs.SelectedRows[0].Cells["Destination"].Value.ToString();

                bool result = _approvedJobService.CompleteJob(jobId, jobNumber, customerFirstName, customerLastName, startLocation, destination);
                if (result)
                {
                    MessageBox.Show("Job marked as completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApprovedJobs();
                    LoadTransportUnits();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to complete job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTrackingJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewTrackingJobs.SelectedRows.Count > 0)
            {
                try
                {
                    int transportUnitId = Convert.ToInt32(dataGridViewTrackingJobs.SelectedRows[0].Cells["TransportUnitID"].Value);
                    TransportUnitView transportUnit = _approvedJobService.GetTransportUnitViewById(transportUnitId);
                    if (transportUnit != null)
                    {
                        cmbTransportID.SelectedValue = transportUnit.TransportUnitID;
                        cmbLorryId.SelectedValue = _approvedJobService.GetAvailableLorries().Find(l => l.LicensePlate == transportUnit.LicensePlate)?.LorryID;
                        cmbDriverId.SelectedValue = _approvedJobService.GetAvailableDrivers().Find(d => d.FirstName == transportUnit.DriverFirstName && d.LastName == transportUnit.DriverLastName)?.DriverID;
                        cmbAssistantId.SelectedValue = _approvedJobService.GetAvailableAssistants().Find(a => a.FirstName == transportUnit.AssistantFirstName && a.LastName == transportUnit.AssistantLastName)?.AssistantID;
                        cmbContainerId.SelectedValue = _approvedJobService.GetAvailableContainers().Find(c => c.ContainerNumber == transportUnit.ContainerNumber)?.ContainerID;
                        cmbStatus.SelectedItem = transportUnit.Status;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading selected transport unit data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbTransportID.SelectedIndex = -1;
            cmbLorryId.SelectedIndex = -1;
            cmbDriverId.SelectedIndex = -1;
            cmbAssistantId.SelectedIndex = -1;
            cmbContainerId.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
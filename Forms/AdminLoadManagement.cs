using e_Shift.Business.Interface;
using e_Shift.Models;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class AdminLoadManagement : Form
    {
        private readonly ILoadService _loadService;

        public AdminLoadManagement(ILoadService loadService)
        {
            InitializeComponent();
            _loadService = loadService;
            this.Text = "Load Management";
            txtLoadID.ReadOnly = true;
            txtLoadNumber.ReadOnly = true;
            dataGridViewLoads.ReadOnly = true;
            ConfigureControls();
        }
        private void ConfigureControls()
        {
            // Set ComboBoxes to DropDownList style to prevent manual entry
            cmbProductListID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJobID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AdminLoadManagement_Load(object sender, EventArgs e)
        {
            PopulateJobComboBox();
            PopulateProductListComboBox();
            PopulateStatusComboBox();
            LoadLoads();
        }

        private void PopulateJobComboBox()
        {
            try
            {
                var jobs = _loadService.GetJobs();
                cmbJobID.DataSource = jobs;
                cmbJobID.DisplayMember = "Value";
                cmbJobID.ValueMember = "Key";
                cmbJobID.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateProductListComboBox()
        {
            try
            {
                var products = _loadService.GetProductLists();
                cmbProductListID.DataSource = products;
                cmbProductListID.DisplayMember = "Value";
                cmbProductListID.ValueMember = "Key";
                cmbProductListID.SelectedIndex = -1;
                cmbProductListID.SelectedIndexChanged += cmbProductListID_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateStatusComboBox()
        {
            cmbStatus.Items.AddRange(new string[] { "Loaded", "In_Transit", "Delivered" });
            cmbStatus.SelectedIndex = -1;
        }

        private void LoadLoads()
        {
            try
            {
                var loads = _loadService.GetAllLoads();
                dataGridViewLoads.DataSource = loads;

                dataGridViewLoads.Columns["LoadID"].HeaderText = "Load ID";
                dataGridViewLoads.Columns["LoadNumber"].HeaderText = "Load Number";
                dataGridViewLoads.Columns["JobID"].HeaderText = "Job ID";
                dataGridViewLoads.Columns["ProductID"].HeaderText = "Product ID";
                dataGridViewLoads.Columns["Quantity"].HeaderText = "Quantity";
                dataGridViewLoads.Columns["Weight"].HeaderText = "Weight (kg)";
                dataGridViewLoads.Columns["Status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading loads: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProductListID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductListID.SelectedValue != null)
            {
                try
                {
                    int productId = Convert.ToInt32(cmbProductListID.SelectedValue);
                    decimal weight = _loadService.GetProductWeight(productId);
                    txtWeight.Text = weight > 0 ? weight.ToString() : "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching weight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var load = new Load
            {
                JobID = Convert.ToInt32(cmbJobID.SelectedValue),
                ProductID = Convert.ToInt32(cmbProductListID.SelectedValue),
                Quantity = int.Parse(txtNumberOfLoads.Text),
                Weight = decimal.Parse(txtWeight.Text),
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (!ValidateInputs(load)) return;

            try
            {
                _loadService.AddLoad(load);
                MessageBox.Show("Load added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadLoads();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoadID.Text))
            {
                MessageBox.Show("Please select a load to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var load = new Load
            {
                LoadID = int.Parse(txtLoadID.Text),
                JobID = Convert.ToInt32(cmbJobID.SelectedValue),
                ProductID = Convert.ToInt32(cmbProductListID.SelectedValue),
                Quantity = int.Parse(txtNumberOfLoads.Text),
                Weight = decimal.Parse(txtWeight.Text),
                Status = cmbStatus.SelectedItem.ToString()
            };

            if (!ValidateInputs(load)) return;

            try
            {
                if (_loadService.UpdateLoad(load))
                {
                    MessageBox.Show("Load updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadLoads();
                }
                else
                {
                    MessageBox.Show("No load found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoadID.Text))
            {
                MessageBox.Show("Please select a load to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtLoadID.Text, out int loadId))
            {
                MessageBox.Show("Invalid Load ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this load?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                if (_loadService.DeleteLoad(loadId))
                {
                    MessageBox.Show("Load deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadLoads();
                }
                else
                {
                    MessageBox.Show("No load found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewLoads_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewLoads.Rows[e.RowIndex];
                txtLoadID.Text = row.Cells["LoadID"].Value.ToString();
                txtLoadNumber.Text = row.Cells["LoadNumber"].Value.ToString();
                cmbJobID.SelectedValue = row.Cells["JobID"].Value;
                cmbProductListID.SelectedValue = row.Cells["ProductID"].Value;
                txtNumberOfLoads.Text = row.Cells["Quantity"].Value.ToString();
                txtWeight.Text = row.Cells["Weight"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }

        private bool ValidateInputs(Load load)
        {
            if (load.JobID <= 0 || cmbJobID.SelectedIndex == -1 ||
                load.ProductID <= 0 || cmbProductListID.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNumberOfLoads.Text) ||
                string.IsNullOrWhiteSpace(txtWeight.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtNumberOfLoads.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Number of Loads must be a valid positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtWeight.Text, out decimal weight) || weight <= 0)
            {
                MessageBox.Show("Weight must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return _loadService.ValidateLoad(load, out string errorMessage);
        }

        private void ClearInputs()
        {
            txtLoadID.Text = "";
            txtLoadNumber.Text = "";
            cmbJobID.SelectedIndex = -1;
            cmbProductListID.SelectedIndex = -1;
            txtNumberOfLoads.Text = "";
            txtWeight.Text = "";
            cmbStatus.SelectedIndex = -1;
        }
    }
}
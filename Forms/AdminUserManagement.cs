using System;
using System.Data;
using System.Windows.Forms;
using e_Shift.Models;
using e_Shift.Business.Interface;

namespace e_Shift.Forms
{
    public partial class AdminUserManagement : Form
    {
        private readonly IAdminManageService _adminService;
        private int _selectedAdminId = -1;
        private bool _isEditMode = false;

        public AdminUserManagement(IAdminManageService adminService)
        {
            InitializeComponent();
            _adminService = adminService;
            this.Text = "User Management";
            SetupDataGridView();
            LoadAdminData();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewUsers.SelectionChanged += DataGridViewUsers_SelectionChanged;
        }

        private void LoadAdminData()
        {
            try
            {
                var admins = _adminService.GetAllAdmins();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("AdminID", typeof(int));
                dataTable.Columns.Add("Username", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("FullName", typeof(string));
                dataTable.Columns.Add("CreatedAt", typeof(DateTime));

                foreach (var admin in admins)
                {
                    dataTable.Rows.Add(admin.AdminID, admin.Username, admin.Email, admin.FullName, admin.CreatedAt);
                }

                dataGridViewUsers.DataSource = dataTable;

                dataGridViewUsers.Columns["AdminID"].HeaderText = "ID";
                dataGridViewUsers.Columns["Username"].HeaderText = "Username";
                dataGridViewUsers.Columns["Email"].HeaderText = "Email";
                dataGridViewUsers.Columns["FullName"].HeaderText = "Full Name";
                dataGridViewUsers.Columns["CreatedAt"].HeaderText = "Created At";

                dataGridViewUsers.Columns["AdminID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading admin data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];
                _selectedAdminId = Convert.ToInt32(selectedRow.Cells["AdminID"].Value);

                txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtFullName.Text = selectedRow.Cells["FullName"].Value.ToString();

                txtPassword.Clear();

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                ClearForm();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                UpdateAdmin();
            }
            else
            {
                RegisterNewAdmin();
            }
        }

        private void RegisterNewAdmin()
        {
            var admin = new AdminManage
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Email = txtEmail.Text.Trim(),
                FullName = txtFullName.Text.Trim()
            };

            if (!_adminService.ValidateAdmin(admin, true, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_adminService.UsernameOrEmailExists(admin.Username, admin.Email, -1, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _adminService.AddAdmin(admin);
                MessageBox.Show("Admin registered successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAdminData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering admin: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAdmin()
        {
            if (_selectedAdminId == -1)
            {
                MessageBox.Show("Please select an admin to update.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var admin = new AdminManage
            {
                AdminID = _selectedAdminId,
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Email = txtEmail.Text.Trim(),
                FullName = txtFullName.Text.Trim()
            };

            if (!_adminService.ValidateAdmin(admin, false, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_adminService.UsernameOrEmailExists(admin.Username, admin.Email, _selectedAdminId, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _adminService.UpdateAdmin(admin);
                MessageBox.Show("Admin updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAdminData();
                ClearForm();
                ExitEditMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating admin: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedAdminId == -1)
            {
                MessageBox.Show("Please select an admin to edit.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EnterEditMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedAdminId == -1)
            {
                MessageBox.Show("Please select an admin to delete.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_adminService.CanDeleteAdmin(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this admin? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _adminService.DeleteAdmin(_selectedAdminId);
                    MessageBox.Show("Admin deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAdminData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting admin: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks if needed
        }

        private void btnShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                txtPassword.UseSystemPasswordChar = !checkBox.Checked;
            }
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtFullName.Clear();
            _selectedAdminId = -1;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            ExitEditMode();
        }

        private void EnterEditMode()
        {
            _isEditMode = true;
            btnRegister.Text = "Update Admin";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ExitEditMode()
        {
            _isEditMode = false;
            btnRegister.Text = "Register Admin";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            ExitEditMode();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAdminData();
            ClearForm();
        }
    }
}
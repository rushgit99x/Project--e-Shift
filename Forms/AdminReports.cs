using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq; // Added to resolve Cast and Select errors
using e_Shift.Business.Interface;

namespace e_Shift.Forms
{
    public partial class AdminReports : Form
    {
        private readonly IReportService _reportService;

        public AdminReports(IReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;
            this.Text = "Reports";
            LoadReportTypes();
            ConfigureControls();
        }
        private void ConfigureControls()
        {
            // Set ComboBoxes to DropDownList style to prevent manual entry
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadReportTypes()
        {
            cmbReportType.Items.AddRange(new string[]
            {
                "Current Jobs",
                "Customer List",
                "Driver List",
                "Assistants List",
                "Completed Jobs",
                "Inventory",
                "Lorries List"
            });
            cmbReportType.SelectedIndex = 0; // Select first item by default
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();
            DataTable reportData = GenerateReport(reportType);
            dataGridViewReports.DataSource = reportData;

            // Auto-size columns
            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private DataTable GenerateReport(string reportType)
        {
            try
            {
                return _reportService.GenerateReport(reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dataGridViewReports.DataSource == null || dataGridViewReports.Rows.Count == 0)
            {
                MessageBox.Show("No data to download. Please generate a report first.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = $"{cmbReportType.SelectedItem}_{DateTime.Now:yyyyMMddHHmmss}.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = (DataTable)dataGridViewReports.DataSource;
                    StringBuilder csvContent = new StringBuilder();

                    // Add headers
                    csvContent.AppendLine(string.Join(",", dt.Columns.Cast<DataColumn>()
                        .Select(column => $"\"{column.ColumnName}\"")));

                    // Add rows
                    foreach (DataRow row in dt.Rows)
                    {
                        csvContent.AppendLine(string.Join(",", row.ItemArray
                            .Select(field => $"\"{field.ToString().Replace("\"", "\"\"")}\"")));
                    }

                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                    MessageBox.Show("Report downloaded successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear previous data when report type changes
            dataGridViewReports.DataSource = null;
        }
    }
}
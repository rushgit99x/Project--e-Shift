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
    public partial class ReviewJobs : Form
    {
        private readonly IJobService _jobService;

        public ReviewJobs()
        {
            InitializeComponent();

            // Dependency injection setup
            IJobRepository jobRepository = new JobRepository();
            ITransportUnitRepository transportUnitRepository = new TransportUnitRepository();
            INotificationRepository notificationRepository = new NotificationRepository();
            _jobService = new JobService(jobRepository, transportUnitRepository, notificationRepository);
            LoadJobs();
            dataGridViewReviewJobs.ReadOnly = true;
        }

        private void LoadJobs()
        {
            try
            {
                List<Job> jobs = _jobService.GetJobsForReview();
                dataGridViewReviewJobs.DataSource = jobs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReviewJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the selected job?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int jobId = Convert.ToInt32(dataGridViewReviewJobs.SelectedRows[0].Cells["JobID"].Value);
                    bool result = _jobService.DeleteJob(jobId);

                    if (result)
                    {
                        LoadJobs();
                        MessageBox.Show("Job deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (dataGridViewReviewJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to decline.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int jobId = Convert.ToInt32(dataGridViewReviewJobs.SelectedRows[0].Cells["JobID"].Value);
                bool result = _jobService.DeclineJob(jobId);

                if (result)
                {
                    LoadJobs();
                    MessageBox.Show("Job declined successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to decline job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error declining job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridViewReviewJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int jobId = Convert.ToInt32(dataGridViewReviewJobs.SelectedRows[0].Cells["JobID"].Value);
                bool result = _jobService.ApproveJob(jobId);

                if (result)
                {
                    LoadJobs();
                    MessageBox.Show("Job approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to approve job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
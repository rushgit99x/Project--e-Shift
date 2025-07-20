using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Forms.Jobs;
using e_Shift.Forms.TransportUnits;
using e_Shift.Repository.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class AdminJobs : Form
    {
        public AdminJobs()
        {
            InitializeComponent();
            this.Text = "Jobs";
        }

        private void btnReviewJobs_Click(object sender, EventArgs e)
        {
            ReviewJobs  reviewJobs = new ReviewJobs ();
            reviewJobs.Show();
            this.Close();
        }

        private void btnApprovedJobs_Click(object sender, EventArgs e)
        {
            ApprovedJobs approvedJobs = new ApprovedJobs();
            approvedJobs.Show();
            this.Close();
        }
    }
}

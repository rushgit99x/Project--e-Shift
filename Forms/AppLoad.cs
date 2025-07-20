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
    public partial class AppLoad : Form
    {
        public AppLoad()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value < 100)
            {
                progressBar.Value += 5;
                lblLoadingPercentage.Text = progressBar.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void AppLoad_Load(object sender, EventArgs e)
        {
            // Initialize progress bar
            progressBar.Value = 0;
            lblLoadingPercentage.Text = "0%";

            // Set timer interval (e.g., 100ms for smooth progress)
            timer1.Interval = 100;
            timer1.Start();
        }
        private void AppLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}

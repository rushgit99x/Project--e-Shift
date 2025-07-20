
using e_Shift.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Shift
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AdminRegister());
            //Application.Run(new LoginForm());
            //Application.Run(new UserRegister());
            //Application.Run(new AdminDashboard());1
            //Application.Run(new UsersDashboard());
            Application.Run(new AdminDashboard());
            //Application.Run(new AppLoad());


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Config
{
    public static class EmailConfig
    {
        public static string SmtpHost => "smtp.gmail.com";
        public static int SmtpPort => 587;
        public static string SenderEmail => "rushbiz99x@gmail.com"; // Replace with your Gmail address
        public static string SenderPassword => "vpur dvgw ijoo napc"; // Replace with your Gmail App Password
        public static string SenderDisplayName => "e-Shift Team";
    }
}

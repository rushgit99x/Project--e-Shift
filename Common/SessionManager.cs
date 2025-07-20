using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Common
{
    public static class SessionManager
    {
        private static Models.Customer _currentCustomer;

        public static Models.Customer CurrentCustomer
        {
            get => _currentCustomer;
            set => _currentCustomer = value;
        }

        public static bool IsLoggedIn => _currentCustomer != null;

        public static void ClearSession()
        {
            _currentCustomer = null;
        }
    }
}

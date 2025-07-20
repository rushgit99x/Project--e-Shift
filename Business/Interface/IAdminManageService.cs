using e_Shift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Business.Interface
{
    public interface IAdminManageService
    {
        List<AdminManage> GetAllAdmins();
        AdminManage GetAdminById(int adminId);
        bool ValidateAdmin(AdminManage admin, bool isNewAdmin, out string errorMessage);
        bool UsernameOrEmailExists(string username, string email, int excludeAdminId, out string errorMessage);
        bool CanDeleteAdmin(out string errorMessage);
        void AddAdmin(AdminManage admin);
        void UpdateAdmin(AdminManage admin);
        void DeleteAdmin(int adminId);
    }
}

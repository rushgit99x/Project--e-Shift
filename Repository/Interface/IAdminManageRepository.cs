using e_Shift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Repository.Interface
{
    public interface IAdminManageRepository
    {
        List<AdminManage> GetAllAdmins();
        AdminManage GetAdminById(int adminId);
        bool UsernameOrEmailExists(string username, string email, int excludeAdminId = -1);
        int CountAdmins();
        void AddAdmin(AdminManage admin);
        void UpdateAdmin(AdminManage admin);
        void DeleteAdmin(int adminId);
    }
}

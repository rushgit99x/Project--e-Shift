using e_Shift.Models;
using System.Threading.Tasks;

namespace e_Shift.Repository.Interface
{
    public interface IAdminRepository
    {
        Task<Admin> GetAdminByCredentialsAsync(string username, string password);
        Task<Admin> RegisterAdminAsync(Admin admin);
    }
}
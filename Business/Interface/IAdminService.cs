using e_Shift.Models;
using System.Threading.Tasks;

namespace e_Shift.Business.Interface
{
    public interface IAdminService
    {
        Task<Admin> LoginAdminAsync(string username, string password);
        Task<Admin> RegisterAdminAsync(string username, string email, string password);
        string HashPassword(string password);
    }
}
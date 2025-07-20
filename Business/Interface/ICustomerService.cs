// Business/Interface/ICustomerService.cs
using e_Shift.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_Shift.Business.Interface
{
    public interface ICustomerService
    {
        Task<Customer> RegisterCustomerAsync(string firstName, string lastName, string email, string password); // Changed from Task<bool> to Task<Customer>
        Task<Customer> LoginCustomerAsync(string email, string password);
        string GenerateCustomerNumber();
        string HashPassword(string password);
        List<Customer> GetAllCustomers();
        bool CanDeleteCustomer(int customerId);
        void DeleteCustomer(int customerId);
    }
}
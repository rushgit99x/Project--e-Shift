using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        }

        public async Task<Admin> LoginAdminAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            string hashedPassword = HashPassword(password);
            Admin admin = await _adminRepository.GetAdminByCredentialsAsync(username, hashedPassword);
            if (admin == null)
            {
                throw new ArgumentException("Invalid username or password.");
            }
            return admin;
        }

        public async Task<Admin> RegisterAdminAsync(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username, email, and password are required.");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("Please enter a valid email address.");
            }

            if (password.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters long.");
            }

            var admin = new Admin
            {
                Username = username,
                Password = HashPassword(password),
                Email = email,
                FullName = "Admin" // Default value since fullName is not provided
            };

            try
            {
                Admin registeredAdmin = await _adminRepository.RegisterAdminAsync(admin);
                if (registeredAdmin == null || registeredAdmin.AdminID <= 0)
                {
                    throw new Exception("Registration failed.");
                }
                return registeredAdmin;
            }
            catch (Exception ex)
            {
                // Log the inner exception for debugging
                string errorMessage = $"Registration failed at {DateTime.Now}: {ex.Message} (Inner: {ex.InnerException?.Message})";
                System.IO.File.AppendAllText("error.log", errorMessage + Environment.NewLine);
                throw;
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace e_Shift.Business.Services
{
    public class AdminManageService : IAdminManageService
    {
        private readonly IAdminManageRepository _repository;

        public AdminManageService(IAdminManageRepository repository)
        {
            _repository = repository;
        }

        public List<AdminManage> GetAllAdmins()
        {
            return _repository.GetAllAdmins();
        }

        public AdminManage GetAdminById(int adminId)
        {
            return _repository.GetAdminById(adminId);
        }

        public bool ValidateAdmin(AdminManage admin, bool isNewAdmin, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(admin.Username))
            {
                errorMessage = "Username is required.";
                return false;
            }

            if (admin.Username.Length < 3)
            {
                errorMessage = "Username must be at least 3 characters long.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(admin.Email))
            {
                errorMessage = "Email is required.";
                return false;
            }

            if (!IsValidEmail(admin.Email))
            {
                errorMessage = "Please enter a valid email address.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(admin.FullName))
            {
                errorMessage = "Full Name is required.";
                return false;
            }

            if (isNewAdmin || !string.IsNullOrEmpty(admin.Password))
            {
                if (string.IsNullOrWhiteSpace(admin.Password))
                {
                    errorMessage = "Password is required.";
                    return false;
                }

                if (admin.Password.Length < 6)
                {
                    errorMessage = "Password must be at least 6 characters long.";
                    return false;
                }
            }

            return true;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool UsernameOrEmailExists(string username, string email, int excludeAdminId, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (_repository.UsernameOrEmailExists(username, email, excludeAdminId))
            {
                errorMessage = "Username or Email already exists.";
                return true;
            }
            return false;
        }

        public bool CanDeleteAdmin(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (_repository.CountAdmins() <= 1)
            {
                errorMessage = "Cannot delete the last admin!";
                return false;
            }
            return true;
        }

        public void AddAdmin(AdminManage admin)
        {
            admin.Password = HashPassword(admin.Password);
            admin.CreatedAt = DateTime.UtcNow;
            _repository.AddAdmin(admin);
        }

        public void UpdateAdmin(AdminManage admin)
        {
            if (!string.IsNullOrEmpty(admin.Password))
                admin.Password = HashPassword(admin.Password);
            _repository.UpdateAdmin(admin);
        }

        public void DeleteAdmin(int adminId)
        {
            _repository.DeleteAdmin(adminId);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
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
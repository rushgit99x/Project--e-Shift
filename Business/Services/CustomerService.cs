using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> RegisterCustomerAsync(string firstName, string lastName, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("All fields are required.");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("Please enter a valid email address.");
            }

            var customer = new Customer
            {
                CustomerNumber = GenerateCustomerNumber(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = HashPassword(password),
                Phone = "",
                Address = ""
            };

            Customer registeredCustomer = await _customerRepository.RegisterCustomerAsync(customer);
            if (registeredCustomer == null || registeredCustomer.CustomerID <= 0)
            {
                throw new Exception("Registration failed.");
            }
            return registeredCustomer;
        }

        public string GenerateCustomerNumber()
        {
            return "CUST" + DateTime.Now.ToString("yyyyMMddHHmmss");
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

        public async Task<Customer> LoginCustomerAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Email and password are required.");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("Please enter a valid email address.");
            }

            string hashedPassword = HashPassword(password);
            Customer customer = await _customerRepository.GetCustomerByCredentialsAsync(email, hashedPassword);
            if (customer == null)
            {
                throw new ArgumentException("Invalid email or password.");
            }
            return customer;
        }
            public CustomerService()
            {
                _customerRepository = new Repository.Services.CustomerRepository(); // Could use DI
            }

            public List<Customer> GetAllCustomers()
            {
                return _customerRepository.GetAllCustomers();
            }

            public bool CanDeleteCustomer(int customerId)
            {
                return !_customerRepository.HasAssociatedJobs(customerId);
            }

            public void DeleteCustomer(int customerId)
            {
                if (!_customerRepository.HasAssociatedJobs(customerId))
                {
                    _customerRepository.DeleteCustomer(customerId);
                }
                else
                {
                    throw new Exception("Cannot delete customer with associated jobs.");
                }
            }
        }
    }

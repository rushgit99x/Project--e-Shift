using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace e_Shift.Business.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void AddDriver(Driver driver)
        {
            _driverRepository.Add(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            _driverRepository.Update(driver);
        }

        public void DeleteDriver(int driverId)
        {
            _driverRepository.Delete(driverId);
        }

        public List<Driver> GetAllDrivers()
        {
            return _driverRepository.GetAll();
        }

        public Driver GetDriverById(int driverId)
        {
            return _driverRepository.GetById(driverId);
        }

        public bool ValidateDriver(Driver driver, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(driver.FirstName))
            {
                errorMessage = "First Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(driver.LastName))
            {
                errorMessage = "Last Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(driver.LicenseNumber))
            {
                errorMessage = "License Number is required.";
                return false;
            }
            if (driver.Status == "Select the status")
            {
                errorMessage = "Please select a valid status.";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(driver.Phone) && !Regex.IsMatch(driver.Phone, @"^\+?\d{10,15}$"))
            {
                errorMessage = "Please enter a valid phone number (10-15 digits, optional '+' prefix).";
                return false;
            }
            return true;
        }
    }
}
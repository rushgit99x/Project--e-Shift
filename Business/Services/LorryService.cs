using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using e_Shift.Business.Interface;

namespace e_Shift.Business.Services
{
    public class LorryService : ILorryService
    {
        private readonly ILorryRepository _lorryRepository;

        public LorryService(ILorryRepository lorryRepository)
        {
            _lorryRepository = lorryRepository;
        }

        public List<Lorry> GetAllLorries()
        {
            return _lorryRepository.GetAllLorries();
        }

        public void AddLorry(Lorry lorry)
        {
            _lorryRepository.AddLorry(lorry);
        }

        public bool UpdateLorry(Lorry lorry)
        {
            return _lorryRepository.UpdateLorry(lorry);
        }

        public bool DeleteLorry(int lorryId)
        {
            return _lorryRepository.DeleteLorry(lorryId);
        }

        public bool ValidateLorry(Lorry lorry, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(lorry.LicensePlate))
            {
                errorMessage = "License plate is required.";
                return false;
            }

            // Validate license plate format (example: 2-3 letters followed by 4-6 digits, e.g., ABC1234 or AB123456)
            if (!Regex.IsMatch(lorry.LicensePlate, @"^[A-Z]{2,3}\d{4,6}$"))
            {
                errorMessage = "Invalid license plate format. It should be 2-3 letters followed by 4-6 digits (e.g., ABC1234).";
                return false;
            }

            if (string.IsNullOrWhiteSpace(lorry.Model))
            {
                errorMessage = "Model is required.";
                return false;
            }

            if (lorry.Capacity <= 0)
            {
                errorMessage = "Please select a valid capacity.";
                return false;
            }

            // Validate capacity against allowed values
            decimal[] validCapacities = { 5.00m, 10.00m, 15.00m, 20.00m, 25.00m };
            if (!Array.Exists(validCapacities, c => c == lorry.Capacity))
            {
                errorMessage = "Invalid capacity selected. Choose from 5, 10, 15, 20, or 25 tons.";
                return false;
            }

            if (string.IsNullOrEmpty(lorry.Status) || lorry.Status == "Select the status")
            {
                errorMessage = "Please select a valid status.";
                return false;
            }

            // Validate status against allowed values
            string[] validStatuses = { "Available", "In_Use", "Maintenance" };
            if (!Array.Exists(validStatuses, s => s == lorry.Status))
            {
                errorMessage = "Invalid status selected.";
                return false;
            }

            return true;
        }
    }
}
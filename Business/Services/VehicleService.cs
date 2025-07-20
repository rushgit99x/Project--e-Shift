using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System.Collections.Generic;

namespace e_Shift.Business.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Add(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }

        public void DeleteVehicle(int lorryId)
        {
            _vehicleRepository.Delete(lorryId);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAll();
        }

        public Vehicle GetVehicleById(int lorryId)
        {
            return _vehicleRepository.GetById(lorryId);
        }

        public bool ValidateVehicle(Vehicle vehicle, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(vehicle.LicensePlate))
            {
                errorMessage = "License Plate is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(vehicle.Model))
            {
                errorMessage = "Model is required.";
                return false;
            }
            if (vehicle.Capacity == 0 || vehicle.Capacity < 0)
            {
                errorMessage = "Please select a valid capacity.";
                return false;
            }
            if (vehicle.Status == "Select the status")
            {
                errorMessage = "Please select a valid status.";
                return false;
            }
            return true;
        }
    }
}
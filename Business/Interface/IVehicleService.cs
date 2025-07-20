using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Business.Interface
{
    public interface IVehicleService
    {
        void AddVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int lorryId);
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicleById(int lorryId);
        bool ValidateVehicle(Vehicle vehicle, out string errorMessage);
    }
}
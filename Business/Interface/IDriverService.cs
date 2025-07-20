using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Business.Interface
{
    public interface IDriverService
    {
        void AddDriver(Driver driver);
        void UpdateDriver(Driver driver);
        void DeleteDriver(int driverId);
        List<Driver> GetAllDrivers();
        Driver GetDriverById(int driverId);
        bool ValidateDriver(Driver driver, out string errorMessage);
    }
}
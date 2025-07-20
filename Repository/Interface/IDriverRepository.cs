using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Repository.Interface
{
    public interface IDriverRepository
    {
        void Add(Driver driver);
        void Update(Driver driver);
        void Delete(int driverId);
        List<Driver> GetAll();
        Driver GetById(int driverId);
        List<Driver> GetAvailableDrivers();
        bool UpdateDriverStatus(int driverId, string status);
        List<Driver> GetAllDrivers();
        void AddDriver(Driver driver);
        bool UpdateDriver(Driver driver);
        bool DeleteDriver(int driverId);
    }
}
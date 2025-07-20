using e_Shift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift.Repository.Interface
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int lorryId);
        List<Vehicle> GetAll();
        Vehicle GetById(int lorryId);
    }
}

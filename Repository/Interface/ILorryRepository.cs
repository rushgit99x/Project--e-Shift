using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface ILorryRepository
    {
        List<Lorry> GetAvailableLorries();
        bool UpdateLorryStatus(int lorryId, string status);
        List<Lorry> GetAllLorries();
        void AddLorry(Lorry lorry);
        bool UpdateLorry(Lorry lorry);
        bool DeleteLorry(int lorryId);
    }
}
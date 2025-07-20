using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Business.Interface
{
    public interface ILorryService
    {
        List<Lorry> GetAllLorries();
        void AddLorry(Lorry lorry);
        bool UpdateLorry(Lorry lorry);
        bool DeleteLorry(int lorryId);
        bool ValidateLorry(Lorry lorry, out string errorMessage);
    }
}
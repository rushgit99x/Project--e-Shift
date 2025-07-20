using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Business.Interface
{
    public interface ILoadService
    {
        List<Load> GetAllLoads();
        void AddLoad(Load load);
        bool UpdateLoad(Load load);
        bool DeleteLoad(int loadId);
        decimal GetProductWeight(int productId);
        List<KeyValuePair<int, string>> GetJobs();
        List<KeyValuePair<int, string>> GetProductLists();
        bool ValidateLoad(Load load, out string errorMessage);
    }
}
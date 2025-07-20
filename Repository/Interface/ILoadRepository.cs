using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface ILoadRepository
    {
        List<Load> GetAllLoads();
        void AddLoad(Load load);
        bool UpdateLoad(Load load);
        bool DeleteLoad(int loadId);
        decimal GetProductWeight(int productId);
        List<KeyValuePair<int, string>> GetJobs(); // For JobID and JobNumber
        List<KeyValuePair<int, string>> GetProductLists(); // For ProductsListID and ProductsList
    }
}
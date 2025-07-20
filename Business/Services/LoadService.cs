using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_Shift.Business.Services
{
    public class LoadService : ILoadService
    {
        private readonly ILoadRepository _loadRepository;

        public LoadService(ILoadRepository loadRepository)
        {
            _loadRepository = loadRepository;
        }

        public List<Load> GetAllLoads()
        {
            return _loadRepository.GetAllLoads();
        }

        public void AddLoad(Load load)
        {
            _loadRepository.AddLoad(load);
        }

        public bool UpdateLoad(Load load)
        {
            return _loadRepository.UpdateLoad(load);
        }

        public bool DeleteLoad(int loadId)
        {
            return _loadRepository.DeleteLoad(loadId);
        }

        public decimal GetProductWeight(int productId)
        {
            return _loadRepository.GetProductWeight(productId);
        }

        public List<KeyValuePair<int, string>> GetJobs()
        {
            return _loadRepository.GetJobs();
        }

        public List<KeyValuePair<int, string>> GetProductLists()
        {
            return _loadRepository.GetProductLists();
        }

        public bool ValidateLoad(Load load, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (load.JobID <= 0)
            {
                errorMessage = "Please select a valid job.";
                return false;
            }

            if (load.ProductID <= 0)
            {
                errorMessage = "Please select a valid product list.";
                return false;
            }

            if (load.Quantity <= 0)
            {
                errorMessage = "Quantity must be a positive integer.";
                return false;
            }

            if (load.Weight <= 0)
            {
                errorMessage = "Weight must be a positive number.";
                return false;
            }

            if (string.IsNullOrEmpty(load.Status) || !new[] { "Loaded", "In_Transit", "Delivered" }.Contains(load.Status))
            {
                errorMessage = "Please select a valid status.";
                return false;
            }

            return true;
        }
    }
}
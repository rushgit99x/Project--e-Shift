using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System.Collections.Generic;

namespace e_Shift.Business.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IContainerRepository _containerRepository;

        public ContainerService(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public void AddContainer(Container container)
        {
            _containerRepository.Add(container);
        }

        public void UpdateContainer(Container container)
        {
            _containerRepository.Update(container);
        }

        public void DeleteContainer(int containerId)
        {
            _containerRepository.Delete(containerId);
        }

        public List<Container> GetAllContainers()
        {
            return _containerRepository.GetAll();
        }

        public Container GetContainerById(int containerId)
        {
            return _containerRepository.GetById(containerId);
        }

        public bool ValidateContainer(Container container, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(container.ContainerNumber))
            {
                errorMessage = "Container Number is required.";
                return false;
            }
            if (container.Capacity == 0 || container.Capacity < 0)
            {
                errorMessage = "Please select a valid capacity.";
                return false;
            }
            if (container.Status == "Select the status")
            {
                errorMessage = "Please select a valid status.";
                return false;
            }
            return true;
        }
    }
}
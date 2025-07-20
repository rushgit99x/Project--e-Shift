using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Business.Interface
{
    public interface IContainerService
    {
        void AddContainer(Container container);
        void UpdateContainer(Container container);
        void DeleteContainer(int containerId);
        List<Container> GetAllContainers();
        Container GetContainerById(int containerId);
        bool ValidateContainer(Container container, out string errorMessage);
    }
}
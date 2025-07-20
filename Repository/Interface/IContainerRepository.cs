using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Repository.Interface
{
    public interface IContainerRepository
    {
        void Add(Container container);
        void Update(Container container);
        void Delete(int containerId);
        List<Container> GetAll();
        Container GetById(int containerId);
        List<Container> GetAvailableContainers();
        bool UpdateContainerStatus(int containerId, string status);
        List<Container> GetAllContainers();
        void AddContainer(Container container);
        bool UpdateContainer(Container container);
        bool DeleteContainer(int containerId);
    }
}
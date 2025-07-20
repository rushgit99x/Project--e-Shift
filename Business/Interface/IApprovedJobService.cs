using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Business.Interface
{
    public interface IApprovedJobService
    {
        List<ApprovedJob> GetApprovedJobs();
        bool CompleteJob(int jobId, string jobNumber, string customerFirstName, string customerLastName, string startLocation, string destination);
        List<Lorry> GetAvailableLorries();
        List<Driver> GetAvailableDrivers();
        List<Assistant> GetAvailableAssistants();
        List<Container> GetAvailableContainers();
        List<string> GetTransportUnitStatuses();
        bool AssignTransportUnit(TransportUnit transportUnit);
        bool UpdateTransportUnit(TransportUnit transportUnit);
        bool DeleteTransportUnit(int transportUnitId);
        List<TransportUnitView> GetTransportUnits();
        TransportUnitView GetTransportUnitViewById(int transportUnitId);
    }
}
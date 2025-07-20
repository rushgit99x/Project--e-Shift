using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface ITransportUnitRepository
    {
        int CreateTransportUnit(TransportUnit transportUnit);
        bool UpdateTransportUnitStatus(int transportUnitId, string status);
        TransportUnit GetTransportUnitById(int transportUnitId);
    }
}
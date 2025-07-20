using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface ITransportUnitViewRepository
    {
        List<TransportUnitView> GetTransportUnits();
        bool DeleteTransportUnit(int transportUnitId);
        TransportUnitView GetTransportUnitViewById(int transportUnitId);
    }
}
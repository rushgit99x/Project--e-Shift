using e_Shift.Models;
using System.Collections.Generic;

using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface IApprovedJobRepository
    {
        List<ApprovedJob> GetApprovedJobs();
        bool CompleteJob(int jobId);
        string GetCustomerEmailByJobId(int jobId);
        int GetTransportUnitIdByJobId(int jobId);
    }
}
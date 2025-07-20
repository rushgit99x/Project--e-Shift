using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Business.Interface
{
    public interface IJobService
    {
        List<Job> GetJobsForReview();
        bool ApproveJob(int jobId);
        bool DeclineJob(int jobId);
        bool DeleteJob(int jobId);
    }
}
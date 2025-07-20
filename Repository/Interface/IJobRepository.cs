using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface IJobRepository
    {
        List<Job> GetJobsForReview();
        bool UpdateJobStatus(int jobId, string status);
        bool DeleteJob(int jobId);
        Job GetJobById(int jobId);
    }
}
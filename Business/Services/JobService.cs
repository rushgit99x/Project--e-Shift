using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using e_Shift.Business.Interface;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Business.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ITransportUnitRepository _transportUnitRepository;
        private readonly INotificationRepository _notificationRepository;

        public JobService(IJobRepository jobRepository, ITransportUnitRepository transportUnitRepository, INotificationRepository notificationRepository)
        {
            _jobRepository = jobRepository;
            _transportUnitRepository = transportUnitRepository;
            _notificationRepository = notificationRepository;
        }

        public List<Job> GetJobsForReview()
        {
            return _jobRepository.GetJobsForReview();
        }

        public bool ApproveJob(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        Job job = _jobRepository.GetJobById(jobId);
                        if (job == null)
                            throw new Exception("Job not found");

                        int transportUnitId = job.TransportUnitID;

                        // Check if transportUnitId is 0, then create a new transport unit
                        if (transportUnitId == 0)
                        {
                            TransportUnit newTransportUnit = new TransportUnit
                            {
                                LorryID = 0, // Yet to assign
                                DriverID = 0, // Yet to assign
                                AssistantID = 0, // Yet to assign
                                ContainerID = 0, // Yet to assign
                                Status = "Pending"
                            };

                            transportUnitId = _transportUnitRepository.CreateTransportUnit(newTransportUnit);

                            // Update job with new TransportUnitID
                            using (MySqlCommand updateJobCmd = new MySqlCommand(
                                "UPDATE jobs SET TransportUnitID = @TransportUnitID, Status = 'Accepted', UpdatedAt = CURRENT_TIMESTAMP WHERE JobID = @JobID",
                                conn, transaction))
                            {
                                updateJobCmd.Parameters.AddWithValue("@TransportUnitID", transportUnitId);
                                updateJobCmd.Parameters.AddWithValue("@JobID", jobId);
                                updateJobCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Update existing transport unit status
                            using (MySqlCommand transportCmd = new MySqlCommand(
                                "UPDATE transportunits SET Status = 'In Transit' WHERE TransportUnitID = @TransportUnitID",
                                conn, transaction))
                            {
                                transportCmd.Parameters.AddWithValue("@TransportUnitID", transportUnitId);
                                transportCmd.ExecuteNonQuery();
                            }

                            // Update job status
                            using (MySqlCommand jobCmd = new MySqlCommand(
                                "UPDATE jobs SET Status = 'Accepted', UpdatedAt = CURRENT_TIMESTAMP WHERE JobID = @JobID",
                                conn, transaction))
                            {
                                jobCmd.Parameters.AddWithValue("@JobID", jobId);
                                jobCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        // Create notification
                        Notification notification = new Notification
                        {
                            RecipientID = job.CustomerID,
                            RecipientType = "Customer",
                            Message = $"Job ID {jobId}: Your job has been approved.",
                            Type = "Email",
                            Status = "Pending"
                        };
                        _notificationRepository.CreateNotification(notification);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error in approve job transaction: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error approving job: {ex.Message}");
            }
        }

        public bool DeclineJob(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        Job job = _jobRepository.GetJobById(jobId);
                        if (job == null)
                            throw new Exception("Job not found");

                        // Update job status
                        using (MySqlCommand jobCmd = new MySqlCommand(
                            "UPDATE jobs SET Status = 'Declined', UpdatedAt = CURRENT_TIMESTAMP WHERE JobID = @JobID",
                            conn, transaction))
                        {
                            jobCmd.Parameters.AddWithValue("@JobID", jobId);
                            jobCmd.ExecuteNonQuery();
                        }

                        // Update transport unit status if it exists
                        if (job.TransportUnitID != 0)
                        {
                            using (MySqlCommand transportCmd = new MySqlCommand(
                                "UPDATE transportunits SET Status = 'Declined' WHERE TransportUnitID = @TransportUnitID",
                                conn, transaction))
                            {
                                transportCmd.Parameters.AddWithValue("@TransportUnitID", job.TransportUnitID);
                                transportCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        // Create notification
                        Notification notification = new Notification
                        {
                            RecipientID = job.CustomerID,
                            RecipientType = "Customer",
                            Message = $"Job ID {jobId}: Your job has been declined.",
                            Type = "Email",
                            Status = "Pending"
                        };
                        _notificationRepository.CreateNotification(notification);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error in decline job transaction: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error declining job: {ex.Message}");
            }
        }

        public bool DeleteJob(int jobId)
        {
            try
            {
                bool result = _jobRepository.DeleteJob(jobId);

                if (result)
                {
                    // Create notification for admin
                    Notification notification = new Notification
                    {
                        RecipientID = 0, // Admin
                        RecipientType = "Admin",
                        Message = $"Job ID {jobId}: Job deleted",
                        Type = "Email",
                        Status = "Pending"
                    };
                    _notificationRepository.CreateNotification(notification);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting job: {ex.Message}");
            }
        }
    }
}
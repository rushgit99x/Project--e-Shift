using System;
using System.Collections.Generic;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using e_Shift.Business.Interface;

namespace e_Shift.Business.Services
{
    public class ApprovedJobService : IApprovedJobService
    {
        private readonly IApprovedJobRepository _approvedJobRepository;
        private readonly ITransportUnitRepository _transportUnitRepository;
        private readonly ITransportUnitViewRepository _transportUnitViewRepository;
        private readonly ILorryRepository _lorryRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IAssistantRepository _assistantRepository;
        private readonly IContainerRepository _containerRepository;
        private readonly INotificationRepository _notificationRepository;

        public ApprovedJobService(
            IApprovedJobRepository approvedJobRepository,
            ITransportUnitRepository transportUnitRepository,
            ITransportUnitViewRepository transportUnitViewRepository,
            ILorryRepository lorryRepository,
            IDriverRepository driverRepository,
            IAssistantRepository assistantRepository,
            IContainerRepository containerRepository,
            INotificationRepository notificationRepository)
        {
            _approvedJobRepository = approvedJobRepository;
            _transportUnitRepository = transportUnitRepository;
            _transportUnitViewRepository = transportUnitViewRepository;
            _lorryRepository = lorryRepository;
            _driverRepository = driverRepository;
            _assistantRepository = assistantRepository;
            _containerRepository = containerRepository;
            _notificationRepository = notificationRepository;
        }

        public List<ApprovedJob> GetApprovedJobs()
        {
            return _approvedJobRepository.GetApprovedJobs();
        }

        public List<Lorry> GetAvailableLorries()
        {
            return _lorryRepository.GetAvailableLorries();
        }

        public List<Driver> GetAvailableDrivers()
        {
            return _driverRepository.GetAvailableDrivers();
        }

        public List<Assistant> GetAvailableAssistants()
        {
            return _assistantRepository.GetAvailableAssistants();
        }

        public List<Container> GetAvailableContainers()
        {
            return _containerRepository.GetAvailableContainers();
        }

        public List<string> GetTransportUnitStatuses()
        {
            return new List<string> { "Pending", "In Transit", "Delivered" };
        }

        public bool AssignTransportUnit(TransportUnit transportUnit)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        int transportUnitId = _transportUnitRepository.CreateTransportUnit(transportUnit);

                        // Update statuses
                        if (transportUnit.LorryID > 0)
                            _lorryRepository.UpdateLorryStatus(transportUnit.LorryID, "In_Use");
                        if (transportUnit.DriverID > 0)
                            _driverRepository.UpdateDriverStatus(transportUnit.DriverID, "Assigned");
                        if (transportUnit.AssistantID > 0)
                            _assistantRepository.UpdateAssistantStatus(transportUnit.AssistantID, "Assigned");
                        if (transportUnit.ContainerID > 0)
                            _containerRepository.UpdateContainerStatus(transportUnit.ContainerID, "In_Use");

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error in assign transport unit transaction: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error assigning transport unit: {ex.Message}");
            }
        }

        public bool UpdateTransportUnit(TransportUnit transportUnit)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        bool updated = _transportUnitRepository.UpdateTransportUnitStatus(transportUnit.TransportUnitID, transportUnit.Status);

                        if (updated)
                        {
                            // Update statuses
                            if (transportUnit.LorryID > 0)
                                _lorryRepository.UpdateLorryStatus(transportUnit.LorryID, "In_Use");
                            if (transportUnit.DriverID > 0)
                                _driverRepository.UpdateDriverStatus(transportUnit.DriverID, "Assigned");
                            if (transportUnit.AssistantID > 0)
                                _assistantRepository.UpdateAssistantStatus(transportUnit.AssistantID, "Assigned");
                            if (transportUnit.ContainerID > 0)
                                _containerRepository.UpdateContainerStatus(transportUnit.ContainerID, "In_Use");

                            transaction.Commit();
                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error in update transport unit transaction: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating transport unit: {ex.Message}");
            }
        }

        public bool DeleteTransportUnit(int transportUnitId)
        {
            try
            {
                bool result = _transportUnitViewRepository.DeleteTransportUnit(transportUnitId);
                if (result)
                {
                    // Create notification for admin
                    Notification notification = new Notification
                    {
                        RecipientID = 0, // Admin
                        RecipientType = "Admin",
                        Message = $"Transport Unit ID {transportUnitId}: Transport unit deleted",
                        Type = "Email",
                        Status = "Pending"
                    };
                    _notificationRepository.CreateNotification(notification);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting transport unit: {ex.Message}");
            }
        }

        public List<TransportUnitView> GetTransportUnits()
        {
            return _transportUnitViewRepository.GetTransportUnits();
        }

        public TransportUnitView GetTransportUnitViewById(int transportUnitId)
        {
            return _transportUnitViewRepository.GetTransportUnitViewById(transportUnitId);
        }

        public bool CompleteJob(int jobId, string jobNumber, string customerFirstName, string customerLastName, string startLocation, string destination)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        string customerEmail = _approvedJobRepository.GetCustomerEmailByJobId(jobId);
                        if (string.IsNullOrEmpty(customerEmail))
                            throw new Exception("Customer email not found");

                        int transportUnitId = _approvedJobRepository.GetTransportUnitIdByJobId(jobId);
                        if (transportUnitId == 0)
                            throw new Exception("No transport unit assigned to this job");

                        TransportUnit transportUnit = _transportUnitRepository.GetTransportUnitById(transportUnitId);
                        if (transportUnit == null)
                            throw new Exception("Transport unit not found");

                        // Update job and transport unit statuses
                        bool jobUpdated = _approvedJobRepository.CompleteJob(jobId);
                        bool transportUpdated = _transportUnitRepository.UpdateTransportUnitStatus(transportUnitId, "Delivered");

                        if (!jobUpdated || !transportUpdated)
                            throw new Exception("Failed to update job or transport unit status");

                        // Update statuses to Available
                        if (transportUnit.LorryID > 0)
                            _lorryRepository.UpdateLorryStatus(transportUnit.LorryID, "Available");
                        if (transportUnit.DriverID > 0)
                            _driverRepository.UpdateDriverStatus(transportUnit.DriverID, "Available");
                        if (transportUnit.AssistantID > 0)
                            _assistantRepository.UpdateAssistantStatus(transportUnit.AssistantID, "Available");
                        if (transportUnit.ContainerID > 0)
                            _containerRepository.UpdateContainerStatus(transportUnit.ContainerID, "Available");

                        // Send email
                        try
                        {
                            MailMessage mail = new MailMessage
                            {
                                From = new MailAddress(EmailConfig.SenderEmail, EmailConfig.SenderDisplayName),
                                Subject = $"Job {jobNumber} Completed",
                                Body = $@"Dear {customerFirstName} {customerLastName},

We are pleased to inform you that your job (Job Number: {jobNumber}) has been successfully completed.

Job Details:
- Start Location: {startLocation}
- Destination: {destination}
- Status: Completed
- Completion Date: {DateTime.Now:MMMM dd, yyyy}

Thank you for choosing e-Shift. If you have any questions or need further assistance, please contact us.

Best regards,
{EmailConfig.SenderDisplayName}",
                                IsBodyHtml = false
                            };
                            mail.To.Add(customerEmail);

                            using (SmtpClient smtp = new SmtpClient(EmailConfig.SmtpHost, EmailConfig.SmtpPort))
                            {
                                smtp.Credentials = new System.Net.NetworkCredential(EmailConfig.SenderEmail, EmailConfig.SenderPassword);
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                            }
                        }
                        catch (SmtpException ex)
                        {
                            // Log the email error but don't fail the transaction
                            Console.WriteLine($"Failed to send email: {ex.Message}");
                        }

                        // Create notification
                        Notification notification = new Notification
                        {
                            RecipientID = _approvedJobRepository.GetTransportUnitIdByJobId(jobId), // CustomerID
                            RecipientType = "Customer",
                            Message = $"Job ID {jobId}: Your job has been completed.",
                            Type = "Email",
                            Status = "Pending"
                        };
                        _notificationRepository.CreateNotification(notification);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error in complete job transaction: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error completing job: {ex.Message}");
            }
        }
    }
}
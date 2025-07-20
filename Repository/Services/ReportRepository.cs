using System;
using System.Data;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class ReportRepository : IReportRepository
    {
        public DataTable GetReportData(string reportType)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = string.Empty;

                    switch (reportType)
                    {
                        case "Current Jobs":
                            query = @"SELECT j.JobID, j.JobNumber, c.CustomerNumber, c.FirstName, c.LastName, 
                                    j.StartLocation, j.Destination, j.Status, j.CreatedAt, j.PreferredDate
                                    FROM jobs j
                                    INNER JOIN customers c ON j.CustomerID = c.CustomerID
                                    WHERE j.Status IN ('Pending', 'Accepted', 'In_Progress')";
                            break;

                        case "Customer List":
                            query = @"SELECT CustomerID, CustomerNumber, FirstName, LastName, 
                                    Email, Phone, Address, RegistrationDate 
                                    FROM customers";
                            break;

                        case "Driver List":
                            query = @"SELECT DriverID, FirstName, LastName, LicenseNumber, 
                                    Phone, Status 
                                    FROM drivers";
                            break;

                        case "Assistants List":
                            query = @"SELECT AssistantID, FirstName, LastName, Phone, Status 
                                    FROM assistants";
                            break;

                        case "Completed Jobs":
                            query = @"SELECT j.JobID, j.JobNumber, c.CustomerNumber, c.FirstName, c.LastName,
                                    j.StartLocation, j.Destination, j.Status, j.CreatedAt, j.PreferredDate
                                    FROM jobs j
                                    INNER JOIN customers c ON j.CustomerID = c.CustomerID
                                    WHERE j.Status = 'Completed'";
                            break;

                        case "Inventory":
                            query = @"SELECT ContainerID, ContainerNumber, Capacity, Status 
                                    FROM containers";
                            break;

                        case "Lorries List":
                            query = @"SELECT LorryID, LicensePlate, Model, Capacity, Status 
                                    FROM lorries";
                            break;

                        default:
                            throw new ArgumentException("Invalid report type.");
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving report data: {ex.Message}");
                }
            }
            return dt;
        }
    }
}
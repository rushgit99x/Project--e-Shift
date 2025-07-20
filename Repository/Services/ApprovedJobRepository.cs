using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class ApprovedJobRepository : IApprovedJobRepository
    {
        public List<ApprovedJob> GetApprovedJobs()
        {
            List<ApprovedJob> jobs = new List<ApprovedJob>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT j.JobID, j.JobNumber, c.FirstName AS CustomerFirstName, c.LastName AS CustomerLastName,
                               j.StartLocation, j.Destination, j.Status, j.PreferredDate, j.CreatedAt
                        FROM jobs j
                        JOIN customers c ON j.CustomerID = c.CustomerID
                        WHERE j.Status = 'Accepted'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        jobs.Add(new ApprovedJob
                        {
                            JobID = reader.GetInt32("JobID"),
                            JobNumber = reader.GetString("JobNumber"),
                            CustomerFirstName = reader.GetString("CustomerFirstName"),
                            CustomerLastName = reader.GetString("CustomerLastName"),
                            StartLocation = reader.GetString("StartLocation"),
                            Destination = reader.GetString("Destination"),
                            Status = reader.GetString("Status"),
                            PreferredDate = reader.GetDateTime("PreferredDate"),
                            CreatedAt = reader.GetDateTime("CreatedAt")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving approved jobs: {ex.Message}");
            }
            return jobs;
        }

        public bool CompleteJob(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE jobs SET Status = 'Completed', UpdatedAt = NOW() WHERE JobID = @JobID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error completing job: {ex.Message}");
            }
        }

        public string GetCustomerEmailByJobId(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT c.Email
                        FROM jobs j
                        JOIN customers c ON j.CustomerID = c.CustomerID
                        WHERE j.JobID = @JobID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving customer email: {ex.Message}");
            }
        }

        public int GetTransportUnitIdByJobId(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT TransportUnitID FROM jobs WHERE JobID = @JobID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);
                    object result = cmd.ExecuteScalar();
                    return result != null && !Convert.IsDBNull(result) ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving transport unit ID: {ex.Message}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class JobRepository : IJobRepository
    {
        public List<Job> GetJobsForReview()
        {
            List<Job> jobs = new List<Job>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT JobID, JobNumber, CustomerID, StartLocation, Destination, 
                                      Status, CreatedAt, PreferredDate, Description, TransportUnitID
                                      FROM jobs
                                      WHERE Status IN ('Pending', 'Accepted', 'Declined')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        jobs.Add(new Job
                        {
                            JobID = reader.GetInt32(reader.GetOrdinal("JobID")),
                            JobNumber = reader.GetString(reader.GetOrdinal("JobNumber")),
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            StartLocation = reader.GetString(reader.GetOrdinal("StartLocation")),
                            Destination = reader.GetString(reader.GetOrdinal("Destination")),
                            Status = reader.GetString(reader.GetOrdinal("Status")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            PreferredDate = reader.GetDateTime(reader.GetOrdinal("PreferredDate")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            TransportUnitID = reader.IsDBNull(reader.GetOrdinal("TransportUnitID")) ? 0 : reader.GetInt32(reader.GetOrdinal("TransportUnitID"))
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving jobs: {ex.Message}");
            }

            return jobs;
        }

        public bool UpdateJobStatus(int jobId, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE jobs SET Status = @Status, UpdatedAt = CURRENT_TIMESTAMP WHERE JobID = @JobID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@JobID", jobId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating job status: {ex.Message}");
            }
        }

        public bool DeleteJob(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM jobs WHERE JobID = @JobID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting job: {ex.Message}");
            }
        }

        public Job GetJobById(int jobId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT JobID, JobNumber, CustomerID, StartLocation, Destination, 
                                      Status, CreatedAt, PreferredDate, Description, TransportUnitID
                                      FROM jobs WHERE JobID = @JobID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Job
                        {
                            JobID = reader.GetInt32(reader.GetOrdinal("JobID")),
                            JobNumber = reader.GetString(reader.GetOrdinal("JobNumber")),
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            StartLocation = reader.GetString(reader.GetOrdinal("StartLocation")),
                            Destination = reader.GetString(reader.GetOrdinal("Destination")),
                            Status = reader.GetString(reader.GetOrdinal("Status")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            PreferredDate = reader.GetDateTime(reader.GetOrdinal("PreferredDate")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            TransportUnitID = reader.IsDBNull(reader.GetOrdinal("TransportUnitID")) ? 0 : reader.GetInt32(reader.GetOrdinal("TransportUnitID"))
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving job: {ex.Message}");
            }
        }
    }
}
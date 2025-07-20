using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace e_Shift.Repository.Services
{
    public class AssistantRepository : IAssistantRepository
    {
        private readonly string _connectionString;

        public AssistantRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }

        public void Add(Assistant assistant)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO assistants (FirstName, LastName, Phone, Status) VALUES (@FirstName, @LastName, @Phone, @Status)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", assistant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", assistant.LastName);
                    cmd.Parameters.AddWithValue("@Phone", assistant.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", assistant.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Assistant assistant)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE assistants SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Status = @Status WHERE AssistantID = @AssistantID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", assistant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", assistant.LastName);
                    cmd.Parameters.AddWithValue("@Phone", assistant.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", assistant.Status);
                    cmd.Parameters.AddWithValue("@AssistantID", assistant.AssistantID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int assistantId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM assistants WHERE AssistantID = @AssistantID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AssistantID", assistantId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Assistant> GetAll()
        {
            var assistants = new List<Assistant>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT AssistantID, FirstName, LastName, Phone, Status FROM assistants";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assistants.Add(new Assistant
                            {
                                AssistantID = reader.GetInt32("AssistantID"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                Status = reader.GetString("Status")
                            });
                        }
                    }
                }
            }
            return assistants;
        }

        public Assistant GetById(int assistantId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT AssistantID, FirstName, LastName, Phone, Status FROM assistants WHERE AssistantID = @AssistantID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AssistantID", assistantId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Assistant
                            {
                                AssistantID = reader.GetInt32("AssistantID"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                Status = reader.GetString("Status")
                            };
                        }
                    }
                }
            }
            return null;
        }
        public List<Assistant> GetAvailableAssistants()
        {
            List<Assistant> assistants = new List<Assistant>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT AssistantID, FirstName, LastName, Status FROM assistants WHERE Status = 'Available'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        assistants.Add(new Assistant
                        {
                            AssistantID = reader.GetInt32("AssistantID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving assistants: {ex.Message}");
            }
            return assistants;
        }

        public bool UpdateAssistantStatus(int assistantId, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE assistants SET Status = @Status WHERE AssistantID = @AssistantID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@AssistantID", assistantId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating assistant status: {ex.Message}");
            }
        }
        public List<Assistant> GetAllAssistants()
        {
            List<Assistant> assistants = new List<Assistant>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT AssistantID, FirstName, LastName, Phone, Status FROM assistants";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        assistants.Add(new Assistant
                        {
                            AssistantID = reader.GetInt32("AssistantID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving assistants: {ex.Message}");
            }
            return assistants;
        }

        public void AddAssistant(Assistant assistant)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO assistants (FirstName, LastName, Phone, Status) 
                                   VALUES (@FirstName, @LastName, @Phone, @Status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", assistant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", assistant.LastName);
                    cmd.Parameters.AddWithValue("@Phone", assistant.Phone ?? (object)DBNull.Value); // Fix applied here
                    cmd.Parameters.AddWithValue("@Status", assistant.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding assistant: {ex.Message}");
            }
        }

        public bool UpdateAssistant(Assistant assistant)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"UPDATE assistants 
                                   SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Status = @Status 
                                   WHERE AssistantID = @AssistantID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", assistant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", assistant.LastName);
                    cmd.Parameters.AddWithValue("@Phone", assistant.Phone ?? (object)DBNull.Value); // Fix applied here
                    cmd.Parameters.AddWithValue("@Status", assistant.Status);
                    cmd.Parameters.AddWithValue("@AssistantID", assistant.AssistantID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating assistant: {ex.Message}");
            }
        }

        public bool DeleteAssistant(int assistantId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM assistants WHERE AssistantID = @AssistantID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AssistantID", assistantId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting assistant: {ex.Message}");
            }
        }
    }
}
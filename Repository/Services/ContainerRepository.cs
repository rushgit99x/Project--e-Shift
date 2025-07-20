using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace e_Shift.Repository.Services
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly string _connectionString;

        public ContainerRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }

        public void Add(Container container)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO containers (ContainerNumber, Capacity, Status) VALUES (@ContainerNumber, @Capacity, @Status)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContainerNumber", container.ContainerNumber);
                    cmd.Parameters.AddWithValue("@Capacity", container.Capacity);
                    cmd.Parameters.AddWithValue("@Status", container.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Container container)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE containers SET ContainerNumber = @ContainerNumber, Capacity = @Capacity, Status = @Status WHERE ContainerID = @ContainerID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContainerNumber", container.ContainerNumber);
                    cmd.Parameters.AddWithValue("@Capacity", container.Capacity);
                    cmd.Parameters.AddWithValue("@Status", container.Status);
                    cmd.Parameters.AddWithValue("@ContainerID", container.ContainerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int containerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM containers WHERE ContainerID = @ContainerID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContainerID", containerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Container> GetAll()
        {
            var containers = new List<Container>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ContainerID, ContainerNumber, Capacity, Status FROM containers";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            containers.Add(new Container
                            {
                                ContainerID = reader.GetInt32("ContainerID"),
                                ContainerNumber = reader.GetString("ContainerNumber"),
                                Capacity = reader.GetDecimal("Capacity"),
                                Status = reader.GetString("Status")
                            });
                        }
                    }
                }
            }
            return containers;
        }

        public Container GetById(int containerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ContainerID, ContainerNumber, Capacity, Status FROM containers WHERE ContainerID = @ContainerID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContainerID", containerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Container
                            {
                                ContainerID = reader.GetInt32("ContainerID"),
                                ContainerNumber = reader.GetString("ContainerNumber"),
                                Capacity = reader.GetDecimal("Capacity"),
                                Status = reader.GetString("Status")
                            };
                        }
                    }
                }
            }
            return null;
        }
        public List<Container> GetAvailableContainers()
        {
            List<Container> containers = new List<Container>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ContainerID, ContainerNumber, Status FROM containers WHERE Status = 'Available'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        containers.Add(new Container
                        {
                            ContainerID = reader.GetInt32("ContainerID"),
                            ContainerNumber = reader.GetString("ContainerNumber"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving containers: {ex.Message}");
            }
            return containers;
        }

        public bool UpdateContainerStatus(int containerId, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE containers SET Status = @Status WHERE ContainerID = @ContainerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ContainerID", containerId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating container status: {ex.Message}");
            }
        }
        public List<Container> GetAllContainers()
        {
            List<Container> containers = new List<Container>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ContainerID, ContainerNumber, Capacity, Status FROM containers";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        containers.Add(new Container
                        {
                            ContainerID = reader.GetInt32("ContainerID"),
                            ContainerNumber = reader.GetString("ContainerNumber"),
                            Capacity = reader.GetDecimal("Capacity"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving containers: {ex.Message}");
            }
            return containers;
        }

        public void AddContainer(Container container)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO containers (ContainerNumber, Capacity, Status) 
                                   VALUES (@ContainerNumber, @Capacity, @Status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ContainerNumber", container.ContainerNumber);
                    cmd.Parameters.AddWithValue("@Capacity", container.Capacity);
                    cmd.Parameters.AddWithValue("@Status", container.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("This container number is already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding container: {ex.Message}");
            }
        }

        public bool UpdateContainer(Container container)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"UPDATE containers 
                                   SET ContainerNumber = @ContainerNumber, Capacity = @Capacity, Status = @Status 
                                   WHERE ContainerID = @ContainerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ContainerNumber", container.ContainerNumber);
                    cmd.Parameters.AddWithValue("@Capacity", container.Capacity);
                    cmd.Parameters.AddWithValue("@Status", container.Status);
                    cmd.Parameters.AddWithValue("@ContainerID", container.ContainerID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("This container number is already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating container: {ex.Message}");
            }
        }

        public bool DeleteContainer(int containerId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM containers WHERE ContainerID = @ContainerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ContainerID", containerId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting container: {ex.Message}");
            }
        }
    }
}
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace e_Shift.Repository.Services
{
    public class DriverRepository : IDriverRepository
    {
        private readonly string _connectionString;

        public DriverRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }

        public void Add(Driver driver)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO drivers (FirstName, LastName, LicenseNumber, Phone, Status) VALUES (@FirstName, @LastName, @LicenseNumber, @Phone, @Status)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", driver.LastName);
                    cmd.Parameters.AddWithValue("@LicenseNumber", driver.LicenseNumber);
                    cmd.Parameters.AddWithValue("@Phone", driver.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", driver.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Driver driver)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE drivers SET FirstName = @FirstName, LastName = @LastName, LicenseNumber = @LicenseNumber, Phone = @Phone, Status = @Status WHERE DriverID = @DriverID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", driver.LastName);
                    cmd.Parameters.AddWithValue("@LicenseNumber", driver.LicenseNumber);
                    cmd.Parameters.AddWithValue("@Phone", driver.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", driver.Status);
                    cmd.Parameters.AddWithValue("@DriverID", driver.DriverID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int driverId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM drivers WHERE DriverID = @DriverID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", driverId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Driver> GetAll()
        {
            var drivers = new List<Driver>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DriverID, FirstName, LastName, LicenseNumber, Phone, Status FROM drivers";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(new Driver
                            {
                                DriverID = reader.GetInt32("DriverID"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                LicenseNumber = reader.GetString("LicenseNumber"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                Status = reader.GetString("Status")
                            });
                        }
                    }
                }
            }
            return drivers;
        }

        public Driver GetById(int driverId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DriverID, FirstName, LastName, LicenseNumber, Phone, Status FROM drivers WHERE DriverID = @DriverID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", driverId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Driver
                            {
                                DriverID = reader.GetInt32("DriverID"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                LicenseNumber = reader.GetString("LicenseNumber"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                Status = reader.GetString("Status")
                            };
                        }
                    }
                }
            }
            return null;
        }
        public List<Driver> GetAvailableDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT DriverID, FirstName, LastName, Status FROM drivers WHERE Status = 'Available'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        drivers.Add(new Driver
                        {
                            DriverID = reader.GetInt32("DriverID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving drivers: {ex.Message}");
            }
            return drivers;
        }

        public bool UpdateDriverStatus(int driverId, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE drivers SET Status = @Status WHERE DriverID = @DriverID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@DriverID", driverId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating driver status: {ex.Message}");
            }
        }
        public List<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT DriverID, FirstName, LastName, LicenseNumber, Phone, Status FROM drivers";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        drivers.Add(new Driver
                        {
                            DriverID = reader.GetInt32("DriverID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            LicenseNumber = reader.GetString("LicenseNumber"),
                            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving drivers: {ex.Message}");
            }
            return drivers;
        }

        public void AddDriver(Driver driver)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO drivers (FirstName, LastName, LicenseNumber, Phone, Status) 
                                   VALUES (@FirstName, @LastName, @LicenseNumber, @Phone, @Status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", driver.LastName);
                    cmd.Parameters.AddWithValue("@LicenseNumber", driver.LicenseNumber);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(driver.Phone) ? (object)DBNull.Value : driver.Phone);
                    cmd.Parameters.AddWithValue("@Status", driver.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("This license number is already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding driver: {ex.Message}");
            }
        }

        public bool UpdateDriver(Driver driver)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"UPDATE drivers 
                                   SET FirstName = @FirstName, LastName = @LastName, LicenseNumber = @LicenseNumber, 
                                       Phone = @Phone, Status = @Status 
                                   WHERE DriverID = @DriverID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", driver.LastName);
                    cmd.Parameters.AddWithValue("@LicenseNumber", driver.LicenseNumber);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(driver.Phone) ? (object)DBNull.Value : driver.Phone);
                    cmd.Parameters.AddWithValue("@Status", driver.Status);
                    cmd.Parameters.AddWithValue("@DriverID", driver.DriverID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("This license number is already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating driver: {ex.Message}");
            }
        }

        public bool DeleteDriver(int driverId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM drivers WHERE DriverID = @DriverID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DriverID", driverId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting driver: {ex.Message}");
            }
        }
    }
}

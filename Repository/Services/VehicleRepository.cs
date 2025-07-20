using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace e_Shift.Repository.Services
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly string _connectionString;

        public VehicleRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }

        public void Add(Vehicle vehicle)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO lorries (LicensePlate, Model, Capacity, Status) VALUES (@LicensePlate, @Model, @Capacity, @Status)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                    cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE lorries SET LicensePlate = @LicensePlate, Model = @Model, Capacity = @Capacity, Status = @Status WHERE LorryID = @LorryID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                    cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                    cmd.Parameters.AddWithValue("@LorryID", vehicle.LorryID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int lorryId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM lorries WHERE LorryID = @LorryID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LorryID", lorryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Vehicle> GetAll()
        {
            var vehicles = new List<Vehicle>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT LorryID, LicensePlate, Model, Capacity, Status FROM lorries";
                using (var cmd = new MySqlCommand(query, connection)) // Fixed: Changed MySqlConnection to MySqlCommand
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Add(new Vehicle
                            {
                                LorryID = reader.GetInt32("LorryID"),
                                LicensePlate = reader.GetString("LicensePlate"),
                                Model = reader.GetString("Model"),
                                Capacity = reader.GetDecimal("Capacity"),
                                Status = reader.GetString("Status")
                            });
                        }
                    }
                }
            }
            return vehicles;
        }

        public Vehicle GetById(int lorryId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT LorryID, LicensePlate, Model, Capacity, Status FROM lorries WHERE LorryID = @LorryID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LorryID", lorryId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Vehicle
                            {
                                LorryID = reader.GetInt32("LorryID"),
                                LicensePlate = reader.GetString("LicensePlate"),
                                Model = reader.GetString("Model"),
                                Capacity = reader.GetDecimal("Capacity"),
                                Status = reader.GetString("Status")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
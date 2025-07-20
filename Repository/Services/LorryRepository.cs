using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class LorryRepository : ILorryRepository
    {
        public List<Lorry> GetAvailableLorries()
        {
            List<Lorry> lorries = new List<Lorry>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT LorryID, LicensePlate, Status FROM lorries WHERE Status = 'Available'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lorries.Add(new Lorry
                        {
                            LorryID = reader.GetInt32("LorryID"),
                            LicensePlate = reader.GetString("LicensePlate"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving lorries: {ex.Message}");
            }
            return lorries;
        }

        public bool UpdateLorryStatus(int lorryId, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE lorries SET Status = @Status WHERE LorryID = @LorryID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@LorryID", lorryId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating lorry status: {ex.Message}");
            }
        }
        public List<Lorry> GetAllLorries()
        {
            List<Lorry> lorries = new List<Lorry>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT LorryID, LicensePlate, Model, Capacity, Status FROM lorries";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lorries.Add(new Lorry
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
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving lorries: {ex.Message}");
            }
            return lorries;
        }

        public void AddLorry(Lorry lorry)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO lorries (LicensePlate, Model, Capacity, Status) 
                                   VALUES (@LicensePlate, @Model, @Capacity, @Status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LicensePlate", lorry.LicensePlate);
                    cmd.Parameters.AddWithValue("@Model", lorry.Model);
                    cmd.Parameters.AddWithValue("@Capacity", lorry.Capacity);
                    cmd.Parameters.AddWithValue("@Status", lorry.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("This license plate is already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding lorry: {ex.Message}");
            }
        }

        public bool UpdateLorry(Lorry lorry)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"UPDATE lorries 
                                   SET LicensePlate = @LicensePlate, Model = @Model, Capacity = @Capacity, Status = @Status 
                                   WHERE LorryID = @LorryID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LicensePlate", lorry.LicensePlate);
                    cmd.Parameters.AddWithValue("@Model", lorry.Model);
                    cmd.Parameters.AddWithValue("@Capacity", lorry.Capacity);
                    cmd.Parameters.AddWithValue("@Status", lorry.Status);
                    cmd.Parameters.AddWithValue("@LorryID", lorry.LorryID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("This license plate is already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating lorry: {ex.Message}");
            }
        }

        public bool DeleteLorry(int lorryId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM lorries WHERE LorryID = @LorryID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LorryID", lorryId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting lorry: {ex.Message}");
            }
        }
    }
}
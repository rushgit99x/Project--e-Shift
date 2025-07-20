using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class TransportUnitViewRepository : ITransportUnitViewRepository
    {
        public List<TransportUnitView> GetTransportUnits()
        {
            List<TransportUnitView> transportUnits = new List<TransportUnitView>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT tu.TransportUnitID, l.LicensePlate, d.FirstName AS DriverFirstName, d.LastName AS DriverLastName,
                               a.FirstName AS AssistantFirstName, a.LastName AS AssistantLastName, c.ContainerNumber, tu.Status
                        FROM transportunits tu
                        JOIN lorries l ON tu.LorryID = l.LorryID
                        JOIN drivers d ON tu.DriverID = d.DriverID
                        JOIN assistants a ON tu.AssistantID = a.AssistantID
                        JOIN containers c ON tu.ContainerID = c.ContainerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        transportUnits.Add(new TransportUnitView
                        {
                            TransportUnitID = reader.GetInt32("TransportUnitID"),
                            LicensePlate = reader.GetString("LicensePlate"),
                            DriverFirstName = reader.GetString("DriverFirstName"),
                            DriverLastName = reader.GetString("DriverLastName"),
                            AssistantFirstName = reader.GetString("AssistantFirstName"),
                            AssistantLastName = reader.GetString("AssistantLastName"),
                            ContainerNumber = reader.GetString("ContainerNumber"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving transport units: {ex.Message}");
            }
            return transportUnits;
        }

        public bool DeleteTransportUnit(int transportUnitId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM transportunits WHERE TransportUnitID = @TransportUnitID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TransportUnitID", transportUnitId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting transport unit: {ex.Message}");
            }
        }

        public TransportUnitView GetTransportUnitViewById(int transportUnitId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT tu.TransportUnitID, l.LicensePlate, d.FirstName AS DriverFirstName, d.LastName AS DriverLastName,
                               a.FirstName AS AssistantFirstName, a.LastName AS AssistantLastName, c.ContainerNumber, tu.Status
                        FROM transportunits tu
                        JOIN lorries l ON tu.LorryID = l.LorryID
                        JOIN drivers d ON tu.DriverID = d.DriverID
                        JOIN assistants a ON tu.AssistantID = a.AssistantID
                        JOIN containers c ON tu.ContainerID = c.ContainerID
                        WHERE tu.TransportUnitID = @TransportUnitID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TransportUnitID", transportUnitId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new TransportUnitView
                        {
                            TransportUnitID = reader.GetInt32("TransportUnitID"),
                            LicensePlate = reader.GetString("LicensePlate"),
                            DriverFirstName = reader.GetString("DriverFirstName"),
                            DriverLastName = reader.GetString("DriverLastName"),
                            AssistantFirstName = reader.GetString("AssistantFirstName"),
                            AssistantLastName = reader.GetString("AssistantLastName"),
                            ContainerNumber = reader.GetString("ContainerNumber"),
                            Status = reader.GetString("Status")
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving transport unit view: {ex.Message}");
            }
        }
    }
}
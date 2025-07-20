using System;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class TransportUnitRepository : ITransportUnitRepository
    {
        public int CreateTransportUnit(TransportUnit transportUnit)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO transportunits (LorryID, DriverID, AssistantID, ContainerID, Status, CreatedAt) 
                                   VALUES (@LorryID, @DriverID, @AssistantID, @ContainerID, @Status, CURRENT_TIMESTAMP)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LorryID", transportUnit.LorryID);
                    cmd.Parameters.AddWithValue("@DriverID", transportUnit.DriverID);
                    cmd.Parameters.AddWithValue("@AssistantID", transportUnit.AssistantID);
                    cmd.Parameters.AddWithValue("@ContainerID", transportUnit.ContainerID);
                    cmd.Parameters.AddWithValue("@Status", transportUnit.Status);

                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.LastInsertedId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating transport unit: {ex.Message}");
            }
        }

        public bool UpdateTransportUnitStatus(int transportUnitId, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE transportunits SET Status = @Status, UpdatedAt = CURRENT_TIMESTAMP WHERE TransportUnitID = @TransportUnitID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@TransportUnitID", transportUnitId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating transport unit status: {ex.Message}");
            }
        }

        public TransportUnit GetTransportUnitById(int transportUnitId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT TransportUnitID, LorryID, DriverID, AssistantID, ContainerID, Status, CreatedAt
                                   FROM transportunits WHERE TransportUnitID = @TransportUnitID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TransportUnitID", transportUnitId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new TransportUnit
                        {
                            TransportUnitID = reader.GetInt32("TransportUnitID"),
                            LorryID = reader.GetInt32("LorryID"),
                            DriverID = reader.GetInt32("DriverID"),
                            AssistantID = reader.GetInt32("AssistantID"),
                            ContainerID = reader.GetInt32("ContainerID"),
                            Status = reader.GetString("Status"),
                            CreatedAt = reader.GetDateTime("CreatedAt")
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving transport unit: {ex.Message}");
            }
        }
    }
}
using System;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class NotificationRepository : INotificationRepository
    {
        public bool CreateNotification(Notification notification)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO notifications (RecipientID, RecipientType, Message, Type, Status, CreatedAt) 
                                   VALUES (@RecipientID, @RecipientType, @Message, @Type, @Status, CURRENT_TIMESTAMP)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RecipientID", notification.RecipientID);
                    cmd.Parameters.AddWithValue("@RecipientType", notification.RecipientType);
                    cmd.Parameters.AddWithValue("@Message", notification.Message);
                    cmd.Parameters.AddWithValue("@Type", notification.Type);
                    cmd.Parameters.AddWithValue("@Status", notification.Status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating notification: {ex.Message}");
            }
        }
    }
}
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace e_Shift.Repository.Service
{
    public class AdminManageRepository : IAdminManageRepository
    {
        public List<AdminManage> GetAllAdmins()
        {
            List<AdminManage> admins = new List<AdminManage>();
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = "SELECT AdminID, Username, Email, FullName, CreatedAt FROM admins ORDER BY CreatedAt DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admins.Add(new AdminManage
                            {
                                AdminID = reader.GetInt32("AdminID"),
                                Username = reader.GetString("Username"),
                                Email = reader.GetString("Email"),
                                FullName = reader.GetString("FullName"),
                                CreatedAt = reader.GetDateTime("CreatedAt")
                            });
                        }
                    }
                }
            }
            return admins;
        }

        public AdminManage GetAdminById(int adminId)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = "SELECT AdminID, Username, Email, FullName, CreatedAt FROM admins WHERE AdminID = @adminId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@adminId", adminId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AdminManage
                            {
                                AdminID = reader.GetInt32("AdminID"),
                                Username = reader.GetString("Username"),
                                Email = reader.GetString("Email"),
                                FullName = reader.GetString("FullName"),
                                CreatedAt = reader.GetDateTime("CreatedAt")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool UsernameOrEmailExists(string username, string email, int excludeAdminId = -1)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM admins WHERE (Username = @username OR Email = @email)";
                if (excludeAdminId != -1)
                    query += " AND AdminID != @adminId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    if (excludeAdminId != -1)
                        cmd.Parameters.AddWithValue("@adminId", excludeAdminId);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public int CountAdmins()
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM admins";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void AddAdmin(AdminManage admin)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO admins (Username, Password, Email, FullName, CreatedAt) 
                                VALUES (@username, @password, @email, @fullname, @createdAt)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", admin.Username);
                    cmd.Parameters.AddWithValue("@password", admin.Password);
                    cmd.Parameters.AddWithValue("@email", admin.Email);
                    cmd.Parameters.AddWithValue("@fullname", admin.FullName);
                    cmd.Parameters.AddWithValue("@createdAt", admin.CreatedAt);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAdmin(AdminManage admin)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = string.IsNullOrEmpty(admin.Password) ?
                    @"UPDATE admins SET Username = @username, Email = @email, FullName = @fullname WHERE AdminID = @adminId" :
                    @"UPDATE admins SET Username = @username, Password = @password, Email = @email, FullName = @fullname WHERE AdminID = @adminId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", admin.Username);
                    if (!string.IsNullOrEmpty(admin.Password))
                        cmd.Parameters.AddWithValue("@password", admin.Password);
                    cmd.Parameters.AddWithValue("@email", admin.Email);
                    cmd.Parameters.AddWithValue("@fullname", admin.FullName);
                    cmd.Parameters.AddWithValue("@adminId", admin.AdminID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAdmin(int adminId)
        {
            using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM admins WHERE AdminID = @adminId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@adminId", adminId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace e_Shift.Repository.Services
{
    public class AdminRepository : IAdminRepository
    {
        public async Task<Admin> RegisterAdminAsync(Admin admin)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert admin data
                            string insertQuery = "INSERT INTO Admins (Username, Password, Email, FullName, CreatedAt) " +
                                                "VALUES (@Username, @Password, @Email, @FullName, NOW());";

                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@Username", admin.Username);
                                insertCmd.Parameters.AddWithValue("@Password", admin.Password);
                                insertCmd.Parameters.AddWithValue("@Email", admin.Email);
                                insertCmd.Parameters.AddWithValue("@FullName", admin.FullName ?? (object)DBNull.Value);

                                await insertCmd.ExecuteNonQueryAsync();
                            }

                            // Retrieve the last inserted row using LAST_INSERT_ID()
                            string selectQuery = "SELECT AdminID, Username, Email, FullName FROM Admins WHERE AdminID = LAST_INSERT_ID();";
                            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn, transaction))
                            {
                                using (MySqlDataReader reader = (MySqlDataReader)await selectCmd.ExecuteReaderAsync())
                                {
                                    if (await reader.ReadAsync())
                                    {
                                        admin.AdminID = reader.GetInt32("AdminID");
                                        admin.Username = reader.GetString("Username");
                                        admin.Email = reader.GetString("Email");
                                        admin.FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName");
                                    }
                                    else
                                    {
                                        throw new Exception("Failed to retrieve the inserted admin ID.");
                                    }
                                }
                            }

                            transaction.Commit();
                            return admin;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            // Log the inner exception for debugging
                            string errorMessage = $"Registration failed at {DateTime.Now}: {ex.Message} (Inner: {ex.InnerException?.Message})";
                            System.IO.File.AppendAllText("error.log", errorMessage + Environment.NewLine);
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                // Check if the error is specifically for the username or email field
                if (ex.Message.Contains("Username"))
                {
                    throw new Exception("Username already registered. Please use a different username.", ex);
                }
                else if (ex.Message.Contains("Email"))
                {
                    throw new Exception("Email already registered. Please use a different email.", ex);
                }
                else
                {
                    throw new Exception("A duplicate entry error occurred.", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the admin: " + ex.Message, ex);
            }
        }

        public async Task<Admin> GetAdminByCredentialsAsync(string username, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT AdminID, Username, Email, FullName " +
                                   "FROM Admins WHERE Username = @Username AND Password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Password", password ?? (object)DBNull.Value);

                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Admin
                                {
                                    AdminID = reader.GetInt32("AdminID"),
                                    Username = reader.GetString("Username"),
                                    Email = reader.GetString("Email"),
                                    FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error occurred while retrieving admin credentials.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving admin credentials.", ex);
            }
        }
    }
}
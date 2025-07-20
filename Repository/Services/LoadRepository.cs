using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class LoadRepository : ILoadRepository
    {
        public List<Load> GetAllLoads()
        {
            List<Load> loads = new List<Load>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT LoadID, LoadNumber, JobID, ProductID, Quantity, Weight, Status FROM loads";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        loads.Add(new Load
                        {
                            LoadID = reader.GetInt32("LoadID"),
                            LoadNumber = reader.GetString("LoadNumber"),
                            JobID = reader.GetInt32("JobID"),
                            ProductID = reader.GetInt32("ProductID"),
                            Quantity = reader.GetInt32("Quantity"),
                            Weight = reader.GetDecimal("Weight"),
                            Status = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving loads: {ex.Message}");
            }
            return loads;
        }

        public void AddLoad(Load load)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string loadNumber = $"LOAD{DateTime.Now:yyyyMMddHHmmss}";
                    string query = "INSERT INTO loads (LoadNumber, JobID, ProductID, Quantity, Weight, Status) " +
                                  "VALUES (@LoadNumber, @JobID, @ProductID, @Quantity, @Weight, @Status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LoadNumber", loadNumber);
                    cmd.Parameters.AddWithValue("@JobID", load.JobID);
                    cmd.Parameters.AddWithValue("@ProductID", load.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", load.Quantity);
                    cmd.Parameters.AddWithValue("@Weight", load.Weight);
                    cmd.Parameters.AddWithValue("@Status", load.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding load: {ex.Message}");
            }
        }

        public bool UpdateLoad(Load load)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE loads SET JobID = @JobID, ProductID = @ProductID, Quantity = @Quantity, " +
                                  "Weight = @Weight, Status = @Status WHERE LoadID = @LoadID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LoadID", load.LoadID);
                    cmd.Parameters.AddWithValue("@JobID", load.JobID);
                    cmd.Parameters.AddWithValue("@ProductID", load.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", load.Quantity);
                    cmd.Parameters.AddWithValue("@Weight", load.Weight);
                    cmd.Parameters.AddWithValue("@Status", load.Status);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating load: {ex.Message}");
            }
        }

        public bool DeleteLoad(int loadId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM loads WHERE LoadID = @LoadID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LoadID", loadId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting load: {ex.Message}");
            }
        }

        public decimal GetProductWeight(int productId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Weight FROM productslist WHERE ProductsListID = @ProductsListID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductsListID", productId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0m;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching weight: {ex.Message}");
            }
        }

        public List<KeyValuePair<int, string>> GetJobs()
        {
            List<KeyValuePair<int, string>> jobs = new List<KeyValuePair<int, string>>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT JobID, JobNumber FROM jobs";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        jobs.Add(new KeyValuePair<int, string>(reader.GetInt32("JobID"), reader.GetString("JobNumber")));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading jobs: {ex.Message}");
            }
            return jobs;
        }

        public List<KeyValuePair<int, string>> GetProductLists()
        {
            List<KeyValuePair<int, string>> products = new List<KeyValuePair<int, string>>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductsListID, ProductsList FROM productslist";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new KeyValuePair<int, string>(reader.GetInt32("ProductsListID"), reader.GetString("ProductsList")));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading product lists: {ex.Message}");
            }
            return products;
        }
    }
}
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using e_Shift.Config;
using e_Shift.Models;
using e_Shift.Repository.Interface;

namespace e_Shift.Repository.Services
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ProductsListID, ProductsList, Weight, CreatedByAdminID FROM productslist";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductsListID = reader.GetInt32("ProductsListID"),
                            ProductsList = reader.GetString("ProductsList"),
                            Weight = reader.GetDecimal("Weight"),
                            CreatedByAdminID = reader.GetInt32("CreatedByAdminID")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving products: {ex.Message}");
            }
            return products;
        }

        public void AddProduct(Product product)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO productslist (ProductsList, Weight, CreatedByAdminID) VALUES (@ProductsList, @Weight, @CreatedByAdminID)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductsList", product.ProductsList.Trim());
                    cmd.Parameters.AddWithValue("@Weight", product.Weight);
                    cmd.Parameters.AddWithValue("@CreatedByAdminID", product.CreatedByAdminID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product: {ex.Message}");
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE productslist SET ProductsList = @ProductsList, Weight = @Weight, CreatedByAdminID = @CreatedByAdminID WHERE ProductsListID = @ProductsListID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductsList", product.ProductsList.Trim());
                    cmd.Parameters.AddWithValue("@Weight", product.Weight);
                    cmd.Parameters.AddWithValue("@CreatedByAdminID", product.CreatedByAdminID);
                    cmd.Parameters.AddWithValue("@ProductsListID", product.ProductsListID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}");
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM productslist WHERE ProductsListID = @ProductsListID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductsListID", productId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}");
            }
        }
    }
}
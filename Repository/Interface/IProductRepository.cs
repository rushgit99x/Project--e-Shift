using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Repository.Interface
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
    }
}
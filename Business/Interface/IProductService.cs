using System.Collections.Generic;
using e_Shift.Models;

namespace e_Shift.Business.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        bool ValidateProduct(Product product, out string errorMessage);
    }
}
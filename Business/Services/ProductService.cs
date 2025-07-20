using System;
using System.Collections.Generic;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using e_Shift.Business.Interface;

namespace e_Shift.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public bool ValidateProduct(Product product, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(product.ProductsList))
            {
                errorMessage = "Product list name is required.";
                return false;
            }

            if (product.Weight <= 0)
            {
                errorMessage = "Weight must be a positive number.";
                return false;
            }

            if (product.CreatedByAdminID <= 0)
            {
                errorMessage = "Created By Admin ID must be a valid positive integer.";
                return false;
            }

            return true;
        }
    }
}
using System.Collections.Generic;
using ProductService.Entities;

namespace ProductService.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        Product AddProduct(Product newProduct);
        Product UpdateProduct(int productId, Product newProduct);
        bool DeleteProduct(int productId);
    }
}
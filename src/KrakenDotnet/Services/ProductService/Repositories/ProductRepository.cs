using System.Collections.Generic;
using ProductService.Entities;

namespace ProductService.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private List<Product> allProducts;

        public ProductRepository()
        {
            allProducts = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "GTX 1050",
                    Description = "GPU",
                    Price = 7000,
                    Quantity = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Intel I7",
                    Description = "CPU",
                    Price = 3000,
                    Quantity = 20
                },
                new Product
                {
                    Id = 3,
                    Name = "SteelSeries Rival 400",
                    Description = "Mouse",
                    Price = 700,
                    Quantity = 30
                },
            };
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return allProducts;
        }

        public Product GetProductById(int productId)
        {
            return allProducts.Find(product => product.Id == productId);
        }

        public Product AddProduct(Product newProduct)
        {
            newProduct.Id = allProducts.Count + 1;

            allProducts.Add(newProduct);
            return newProduct;
        }

        public Product UpdateProduct(int productId, Product newProduct)
        {
            var foundProduct = allProducts.Find(product => product.Id == productId);
            if (foundProduct == null)
            {
                return null;
            }
            foundProduct.Name = newProduct.Name;
            foundProduct.Description = newProduct.Description;
            foundProduct.Price = newProduct.Price;
            foundProduct.Quantity = newProduct.Quantity;

            return foundProduct;
        }

        public bool DeleteProduct(int productId)
        {
            var foundProduct = allProducts.Find(product => product.Id == productId);
            if (foundProduct == null)
            {
                return false;
            }
            allProducts.Remove(foundProduct);
            return true;
        }
    }
}
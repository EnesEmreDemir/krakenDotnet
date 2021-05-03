using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductService.Entities;
using ProductService.Repositories;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return new ObjectResult(_productRepository.GetAllProducts());
        }


        [HttpGet("{productId}")]
        public ActionResult<Product> Get(int productId)
        {
            return new ObjectResult(_productRepository.GetProductById(productId));
        }


        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product newProduct)
        {
            return new ObjectResult(_productRepository.AddProduct(newProduct));
        }

        [HttpPut("{productId}")]
        public ActionResult<Product> Put(int productId, [FromBody] Product newProduct)
        {
            var foundProduct = _productRepository.UpdateProduct(productId, newProduct);
            if (foundProduct == null)
            {
                return new NotFoundObjectResult(productId);
            }
            return foundProduct;
        }


        [HttpDelete("{productId}")]
        public ActionResult Delete(int productId)
        {
            var isDeleted = _productRepository.DeleteProduct(productId);
            if (!isDeleted)
            {
                return new NotFoundObjectResult(productId);
            }
            return Ok();
        }
    }
}
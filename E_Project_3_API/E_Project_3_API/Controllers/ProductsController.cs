using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductsController(IProductServices productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.GetProduct(id);
            if(result == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductRequest request)
        {
            var result = _productService.CreateProduct(request);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductRequest request)
        {
            var result = _productService.UpdateProduct(id, request);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}

using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Services;
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
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProduct(id);
            if (result == null)
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
        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingProducts(int startIndex, int limit)
        {
            var result = _productService.GetPagingProducts(startIndex, limit);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetLengthOfProducts()
        {
            var result = _productService.GetAllProducts().Count();
            return Ok(result);
        }
        [HttpGet("{typeId}/{startIndex}/{limit}")]
        public IActionResult GetPagingProductsByType(int typeId, int startIndex, int limit)
        {
            var result = _productService.GetPagingProductsByType(typeId, startIndex, limit);
            return Ok(result);
        }
        [HttpGet("{typeId}")]
        public IActionResult GetLengthOfProductsByType(int typeId)
        {
            var result = _productService.GetAllProductsByType(typeId).Count();
            return Ok(result);
        }
        [HttpGet("{typeId}/{startIndex}/{limit}/{searchText}")]
        public IActionResult GetPagingSearchProductsByType(int typeId, int startIndex, int limit, string searchText)
        {
            var result = _productService.GetPagingSearchProductsByType(typeId, startIndex, limit, searchText);
            return Ok(result);
        }
        [HttpGet("{typeId}/{searchText}")]
        public IActionResult GetLengthOfSearchProductsByType(int typeId, string searchText)
        {
            var result = _productService.GetAllSearchProductsByType(typeId, searchText).Count();
            return Ok(result);
        }

    }
}

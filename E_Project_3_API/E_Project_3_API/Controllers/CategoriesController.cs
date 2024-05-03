using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryServices.GetAllCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _categoryServices.GetCategory(id);
                return Ok(category);
            }
            catch
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                }); ;
            }
            
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryRequest category)
        {
            var result = _categoryServices.CreateCategory(category);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryRequest category)
        {
            var result = _categoryServices.UpdateCategory(id, category);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryServices.DeleteCategory(id);
            return Ok(result);
        }

        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingCategories(int startIndex, int limit)
        {
            var result = _categoryServices.GetPagingCategories(startIndex, limit);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetLengthOfCategories()
        {
            var result = _categoryServices.GetAllCategories().Count();
            return Ok(result);
        }
    }
}

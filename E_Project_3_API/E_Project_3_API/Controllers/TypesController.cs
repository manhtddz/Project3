using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeServices _typeServices;
        public TypesController(ITypeServices typeServices)
        {
            _typeServices = typeServices;
        }
        [HttpGet]
        public IActionResult GetAllTypes()
        {
            var types = _typeServices.GetAllTypes();
            return Ok(types);
        }
        [HttpGet("{id}")]
        public IActionResult GetTypeById(int id)
        {
            try
            {
                var type = _typeServices.GetType(id);
                return Ok(type);
            }
            catch
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
        }
        [HttpPost]
        public IActionResult CreateType(TypeRequest type)
        {
            var result = _typeServices.CreateType(type);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateType(int id, TypeRequest type)
        {
            var result = _typeServices.UpdateType(id, type);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteType(int id)
        {
            var result = _typeServices.DeleteType(id);
            return Ok(result);
        }

        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingTypes(int startIndex,int limit)
        {
            var result = _typeServices.GetPagingTypes(startIndex,limit);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetLengthOfTypes()
        {
            var result = _typeServices.GetAllTypes().Count();
            return Ok(result);
        }
    }
}

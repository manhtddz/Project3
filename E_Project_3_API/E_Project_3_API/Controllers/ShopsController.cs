using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopServices _shopServices;

        public ShopController(IShopServices shopServices)
        {
            _shopServices = shopServices;
        }

        [HttpGet]
        public IActionResult GetAllShops()
        {
            var shops = _shopServices.GetAllShops();
            return Ok(shops);
        }

        [HttpGet("{id}")]
        public IActionResult GetShopById(int id)
        {
            var shop = _shopServices.GetShop(id);
            if (shop == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(shop);
        }

        [HttpPost]
        public IActionResult CreateShop(ShopRequest request)
        {
            var result = _shopServices.CreateShop(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShop(int id, ShopRequest request)
        {
         
            var result = _shopServices.UpdateShop(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShop(int id)
        {
            var result = _shopServices.DeleteShop(id);
            return Ok(result);
        }

        [HttpGet("{startIndex}/{limit}")]
        public IActionResult GetPagingShops(int startIndex, int limit)
        {
            var result = _shopServices.GetPagingShops(startIndex, limit);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetLengthOfShops()
        {
            var result = _shopServices.GetAllShops().Count();
            return Ok(result);
        }
    }
}

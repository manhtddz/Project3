using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        [HttpPost()]
        public IActionResult Register(UserRegisterDto request)
        {
            var result =  _authentication.Register(request);
            return Ok(result);
        }
        [HttpPost()]
        public IActionResult Login(UserLoginDto request)
        {
            var result = _authentication.Login(request);
            return Ok(result);
        }
        [HttpPost()]
        public IActionResult CreateUser(UserRequest request)
        {
            var result = _authentication.CreateUser(request);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllUsersAndAdmins()
        {
            var result = _authentication.GetAllUsersAndAdmins();
            return Ok(result);
        }
        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _authentication.GetUserByEmail(email);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _authentication.GetAllUsers();
            return Ok(result);
        }
    }
}

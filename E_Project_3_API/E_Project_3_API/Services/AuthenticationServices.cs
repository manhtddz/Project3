using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services.Utility;

namespace E_Project_3_API.Services
{
    public class AuthenticationServices : IAuthentication
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public AuthenticationServices(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        public RegisterResponse Register(UserRegisterDto request)
        {
            RegisterResponse registerResponse = new RegisterResponse();
            var existedUser = _dataContext.Set<User>().ToList().SingleOrDefault(u => u.Username == request.UserName || u.Email == request.Email);
            if (request.UserName != "" && request.Password != "" && request.Email != "")
            {
                if (existedUser != null)
                {
                    registerResponse.Errors.ExistedError = "User is existed";
                    if (!RegexManagement.IsEmail(request.Email))
                    {
                        registerResponse.Errors.EmailError = "Email is not be accepted";
                    }
                    return registerResponse;
                }
               
                var newUser = new User()
                {
                    Username = request.UserName,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Email = request.Email,
                    Role = true
                };
                _dataContext.Add(newUser);
                _dataContext.SaveChanges();
                registerResponse.isRegistered = true;
                return registerResponse;
            }
            else
            {
                if(request.UserName == "")
                {
                    registerResponse.Errors.UsernameError = "Username is required";
                }
                if (request.Password == "")
                {
                    registerResponse.Errors.PasswordError = "Password is required";
                }
                if (request.Email == "")
                {
                    registerResponse.Errors.EmailError = "Email is required";
                }
               
                return registerResponse;
            }
        }

        public LoginResponse Login(UserLoginDto request)
        {
            LoginResponse loginResponse = new LoginResponse();
            var foundUser = _dataContext.Set<User>().ToList().SingleOrDefault(u => u.Username == request.UserName);
            if (request.UserName != "" && request.Password != "")
            {
                if (foundUser == null)
                {
                    loginResponse.Errors.NotExistedError = "User is not existed";
                    return loginResponse;
                }
                if(!BCrypt.Net.BCrypt.Verify(request.Password,foundUser.PasswordHash))
                {
                    loginResponse.Errors.PasswordError = "Wrong password";
                    return loginResponse;
                }

                loginResponse.Token = CreateToken(foundUser);
                loginResponse.isLogin = true;
                return loginResponse;

                //var newUser = new User()
                //{
                //    Username = request.Username,
                //    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                //    Address = request.Address,
                //    Email = request.Email
                //};
                //_dataContext.Add(newUser);
                //_dataContext.SaveChanges();
                //registerResponse.isRegistered = true;
                //return registerResponse;
            }
            else
            {
                if (request.UserName == "")
                {
                    loginResponse.Errors.UsernameEmptyError = "Username is required";
                }
                if (request.Password == "")
                {
                    loginResponse.Errors.PasswordEmptyError = "Password is required";
                }

                return loginResponse;
            }
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}

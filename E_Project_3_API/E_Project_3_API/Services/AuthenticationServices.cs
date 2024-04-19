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
using System.Collections.Generic;

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
                    return registerResponse;
                }
                if (!RegexManagement.IsEmail(request.Email))
                {
                    registerResponse.Errors.EmailError = "Email is not be accepted";
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
                if (request.UserName == "")
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
                if (!BCrypt.Net.BCrypt.Verify(request.Password, foundUser.PasswordHash))
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

        public UserModifyResponse CreateUser(UserRequest request)
        {
            var response = new UserModifyResponse();
            var existedUser = _dataContext.Set<User>().ToList().SingleOrDefault(u => u.Email == request.Email && u.Role == false);
            if (request.Email != "")
            {
                if (existedUser != null)
                {
                    response.Errors.ExistedError = "User is created";
                    return response;
                }
                if (!RegexManagement.IsEmail(request.Email))
                {
                    response.Errors.EmailError = "Email is not be accepted";
                    return response;
                }
                var newUser = new User()
                {
                    Email = request.Email
                };
                _dataContext.Add(newUser);
                _dataContext.SaveChanges();
                response.isModified = true;
                return response;
            }
            else
            {
                if (request.Email == "")
                {
                    response.Errors.EmailError = "Email is required";
                }

                return response;
            }
        }

        public List<UserResponse> GetAllUsersAndAdmins()
        {
            var users = _dataContext.Set<User>().ToList();
            var responses = new List<UserResponse>();
            foreach (var user in users)
            {
                responses.Add(new UserResponse
                {
                    Id = user.Id,
                    Email = user.Email,
                    Active = user.Active,
                    Role = user.Role
                });
            }
            return responses;
        }
        public UserResponse GetUserByEmail(string email)
        {
            var user = _dataContext.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                return null;
            }
            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Active = user.Active
            };
        }
        public List<UserResponse> GetAllUsers()
        {
            var users = _dataContext.Set<User>().ToList();
            var responses = new List<UserResponse>();
            foreach (var user in users)
            {
                if (!user.Role)
                {
                    responses.Add(new UserResponse
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Active = user.Active,
                        Role = user.Role
                    });
                }
            }
            return responses;
        }
        public List<UserResponse> GetAllPagingUsers(int startIndex, int limit)
        {
            var users = GetAllUsers();
            var responses = new List<UserResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= users.Count)
                {
                    break;
                }
                responses.Add(users[i]);
            }
            return responses;
        }

    }
}

﻿using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IAuthentication
    {
        RegisterResponse Register(UserRegisterDto request);
        LoginResponse Login(UserLoginDto request);
        UserModifyResponse CreateUser(UserRequest request);
        List<UserResponse> GetAllUsersAndAdmins();
        List<UserResponse> GetAllUsers();
        List<UserResponse> GetAllPagingUsers(int startIndex, int limit);
        UserResponse GetUserByEmail(string email);
        string CreateToken(User user);
    }
}

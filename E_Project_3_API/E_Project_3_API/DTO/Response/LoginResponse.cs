using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class LoginResponse
    {
        public string UserName { get; set; } = "";
        public LoginError Errors { get; set; } = new LoginError();
        public string Token { get; set; } = "";
    }
}

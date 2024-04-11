using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class LoginResponse
    {
        public bool isLogin { get; set; } = false;
        public LoginError Errors { get; set; } = new LoginError();
        public string Token { get; set; } = "";
    }
}

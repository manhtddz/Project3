using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class RegisterResponse
    {
        public bool isRegistered { get; set; } = false;
        public RegisterError Errors { get; set; } = new RegisterError();

    }
}

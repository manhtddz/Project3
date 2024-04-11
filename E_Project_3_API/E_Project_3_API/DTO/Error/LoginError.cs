namespace E_Project_3_API.DTO.Error
{
    public class LoginError
    {
        public string NotExistedError { get; set; } = "";
        public string PasswordError { get; set; } = "";
        public string UsernameEmptyError { get; set; } = "";
        public string PasswordEmptyError { get; set; } = "";

    }
}

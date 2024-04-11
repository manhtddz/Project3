namespace E_Project_3_API.DTO.Error
{
    public class RegisterError
    {
        public string ExistedError { get; set; } = "";
        public string EmailError { get; set; } = "";
        public string UsernameError { get; set; } = "";
        public string PasswordError { get; set; } = "";

    }
}

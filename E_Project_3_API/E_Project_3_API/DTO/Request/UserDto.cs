namespace E_Project_3_API.DTO.Request
{
        public class UserRegisterDto
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }

    }
        public class UserLoginDto
        {
            public required string UserName { get; set; }
            public required string Password { get; set; }
        }
}

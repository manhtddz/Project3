using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool Role {  get; set; }
    }
    public class UserModifyResponse
    {
        public bool isModified { get; set; } = false;
        public UserError Errors { get; set; } = new UserError();
    }
}

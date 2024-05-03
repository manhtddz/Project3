using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class FeedbackResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Content { get; set; }
    }
    public class FeedbackModifyResponse
    {
        public bool isModified { get; set; } = false;
        public FeedbackError Errors { get; set; } = new FeedbackError();
    }
}

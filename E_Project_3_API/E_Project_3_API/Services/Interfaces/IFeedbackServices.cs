using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IFeedbackServices
    {
        List<FeedbackResponse> GetAllFeedbacks();
        FeedbackResponse GetFeedbackById(int id);
        FeedbackModifyResponse CreateFeedback(FeedbackRequest request);
        List<FeedbackResponse> GetPagingFeedbacksByUser(int startIndex, int limit, int userId);
        List<FeedbackResponse> GetAllFeedbacksByUser(int userId);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services;

namespace E_Project_3_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;

        public FeedbacksController(IFeedbackServices feedbacktServices)
        {
            _feedbackServices = feedbacktServices;
        }

        [HttpPost()]
        public IActionResult CreateFeedback(FeedbackRequest request)
        {
            var response = _feedbackServices.CreateFeedback(request);
            return Ok(response);
        }

        [HttpGet()]
        public IActionResult GetAllFeedbacks()
        {
            var response = _feedbackServices.GetAllFeedbacks();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            var response = _feedbackServices.GetFeedbackById(id);
            if (response == null)
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                });
            }
            return Ok(response);
        }

        [HttpGet("{userId}/{startIndex}/{limit}")]
        public IActionResult GetPagingFeedbacksByUser(int userId, int startIndex, int limit)
        {
            var result = _feedbackServices.GetPagingFeedbacksByUser(startIndex, limit, userId);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetLengthOfFeedbackByUser(int userId)
        {
            var result = _feedbackServices.GetAllFeedbacksByUser(userId).Count();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult FeedbacksQuantity()
        {
            return Ok(_feedbackServices.GetAllFeedbacks().Count());
        }
    }
}

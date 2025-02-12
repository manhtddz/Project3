using Azure;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services.Utility;
using System.Collections.Generic;
using System.Net.Sockets;

namespace E_Project_3_API.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly DataContext _dataContext;
        public FeedbackServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public FeedbackResponse Convert(Feedback feedback)
        {
            var feedbackResponse = new FeedbackResponse()
            {
                Id = feedback.Id,
                Content = feedback.Content,
                UserEmail = feedback.User.Email,
                UserId = feedback.User.Id
            };
            return feedbackResponse;
        }
        public FeedbackModifyResponse CreateFeedback(FeedbackRequest request)
        {
            var feedbackModifyResponse = new FeedbackModifyResponse();
            var existedUser = _dataContext.Users.SingleOrDefault(u => u.Email == request.UserEmail);
            if (request.Content != "" && request.UserEmail != "")
            {

                if (!RegexManagement.IsEmail(request.UserEmail))
                {
                    feedbackModifyResponse.Errors.UserEmailError = "Email is not be accepted";
                    return feedbackModifyResponse;
                }
                if (existedUser != null)
                {
                    var newFeedback = new Feedback()
                    {
                        User = existedUser,
                        Content = request.Content
                    };
                    _dataContext.Add(newFeedback);
                    _dataContext.SaveChanges();
                    feedbackModifyResponse.isModified = true;
                    return feedbackModifyResponse;
                }
                else
                {
                    var newUser = new User()
                    {
                        Email = request.UserEmail,
                        Role = false,
                        Active = true
                    };
                    _dataContext.Add<User>(newUser);
                    _dataContext.SaveChanges();

                    var newFeedback = new Feedback()
                    {
                        User = newUser,
                        Content = request.Content
                    };
                    _dataContext.Add(newFeedback);
                    _dataContext.SaveChanges();
                    feedbackModifyResponse.isModified = true;
                    return feedbackModifyResponse;

                }
            }
            else
            {
                if (request.Content == "")
                {
                    feedbackModifyResponse.Errors.EmptyFeedbackError = "Feedback is empty";
                }
                if (request.UserEmail == "")
                {
                    feedbackModifyResponse.Errors.UserEmailError = "Please enter your email";
                }
                return feedbackModifyResponse;
            }
        }

        public List<FeedbackResponse> GetAllFeedbacks()
        {
            var feedbacks = _dataContext.Set<Feedback>().ToList();
            var responses = new List<FeedbackResponse>();
            foreach (var feedback in feedbacks)
            {
                responses.Add(Convert(feedback));
            }
            return responses;
        }

        public FeedbackResponse GetFeedbackById(int id)
        {
            var feedback = _dataContext.Find<Feedback>(id);
            if (feedback == null)
            {
                throw new Exception();
            }
            return Convert(feedback);
        }

        public List<FeedbackResponse> GetPagingFeedbacksByUser(int startIndex, int limit, int userId)
        {
            var feedbacks = from u in _dataContext.Users
                            join f in _dataContext.Feedbacks on u.Id equals f.User.Id
                            where u.Id == userId
                            select new
                            {
                                FeedbackId = f.Id,
                            };
            var takenFeedbacks = new List<Feedback>();
            var responses = new List<FeedbackResponse>();
            foreach (var item in feedbacks)
            {
                takenFeedbacks.Add(_dataContext.Find<Feedback>(item.FeedbackId));
            }
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= takenFeedbacks.Count)
                {
                    break;
                }
                responses.Add(Convert(takenFeedbacks[i]));
            }
            return responses;
        }

        public List<FeedbackResponse> GetAllFeedbacksByUser(int userId)
        {
            var feedbacks = from u in _dataContext.Users
                            join f in _dataContext.Feedbacks on u.Id equals f.User.Id
                            where u.Id == userId
                            select new
                            {
                                FeedbackId = f.Id,
                            };
            var takenFeedbacks = new List<Feedback>();
            var responses = new List<FeedbackResponse>();
            foreach (var item in feedbacks)
            {
                takenFeedbacks.Add(_dataContext.Find<Feedback>(item.FeedbackId));
            }
            foreach (var item in takenFeedbacks)
            {
                responses.Add(Convert(item));
            }
            return responses;
        }

    }
}

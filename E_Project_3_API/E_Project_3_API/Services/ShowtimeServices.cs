using System;
using System.Collections.Generic;
using System.Linq;
using E_Project_3_API.DTO.Error;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class ShowtimeServices : IShowtimeServices
    {
        private readonly DataContext _dataContext;

        public ShowtimeServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ShowtimeModifyResponse CreateShowtime(ShowtimeRequest request)
        {
            var response = new ShowtimeModifyResponse();

            if (request.EndTime <= request.StartTime)
            {
                response.Error.Error = "End time must be greater than start time.";
                return response;
            }

           
            var newShowtime = new Showtime
            {
                StartTime = request.StartTime,
                EndTime = request.EndTime
            };

            _dataContext.Showtimes.Add(newShowtime);
            _dataContext.SaveChanges();

            response.IsModified = true;
            return response;
        }

        public List<ShowtimeResponse> GetAllShowtimes()
        {
            var showtimes = _dataContext.Showtimes.ToList();
            var response = new List<ShowtimeResponse>();

            foreach (var showtime in showtimes)
            {
                var showtimeResponse = new ShowtimeResponse
                {
                    Id = showtime.Id,
                    StartTime = showtime.StartTime,
                    EndTime = showtime.EndTime
                };

                response.Add(showtimeResponse);
            }

            return response;
        }

        public ShowtimeResponse GetShowtime(int id)
        {
            var showtime = _dataContext.Showtimes.Find(id);
            if (showtime == null)
            {
                return null;
            }

            var response = new ShowtimeResponse
            {
                Id = showtime.Id,
                StartTime = showtime.StartTime,
                EndTime = showtime.EndTime
            };

            return response;
        }

        //public ShowtimeModifyResponse UpdateShowtime(int id, ShowtimeRequest request)
        //{
        //    var response = new ShowtimeModifyResponse();

           
        //    if (request.EndTime <= request.StartTime)
        //    {
        //        response.Error.EndTimeError = "End time must be greater than start time.";
        //        return response;
        //    }

        //    var existingShowtime = _dataContext.Showtimes.Find(id);
        //    if (existingShowtime == null)
        //    {
        //        response.Error.EndTimeError = "Showtime not found.";
        //        return response;
        //    }

           
        //    existingShowtime.StartTime = request.StartTime;
        //    existingShowtime.EndTime = request.EndTime;

        //    _dataContext.SaveChanges();

        //    response.IsModified = true;
        //    return response;
        //}

        public ShowtimeModifyResponse DeleteShowtime(int id)
        {
            var response = new ShowtimeModifyResponse();

           
            var showtimeToDelete = _dataContext.Showtimes.Find(id);
            if (showtimeToDelete == null)
            {
                response.Error.Error = "Showtime not found.";
                return response;
            }

            _dataContext.Showtimes.Remove(showtimeToDelete);
            _dataContext.SaveChanges();

            response.IsModified = true;
            return response;
        }
    }
}

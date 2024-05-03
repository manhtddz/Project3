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
                var showtimeResponse = new ShowtimeResponse();

                showtimeResponse.Id = showtime.Id;
                if (showtime.EndTime.Minute < 10)
                {
                    showtimeResponse.EndTime = showtime.EndTime.Hour + ":0" + showtime.EndTime.Minute;
                }
                else
                {
                    showtimeResponse.EndTime = showtime.EndTime.Hour + ":" + showtime.EndTime.Minute;
                }

                if (showtime.StartTime.Minute < 10)
                {
                    showtimeResponse.StartTime = showtime.StartTime.Hour + ":0" + showtime.StartTime.Minute;
                }
                else
                {
                    showtimeResponse.StartTime = showtime.StartTime.Hour + ":" + showtime.StartTime.Minute;
                }

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

            var response = new ShowtimeResponse();

            response.Id = showtime.Id;
            if (showtime.EndTime.Minute < 10)
            {
                response.EndTime = showtime.EndTime.Hour + ":0" + showtime.EndTime.Minute;
            }
            else
            {
                response.EndTime = showtime.EndTime.Hour + ":" + showtime.EndTime.Minute;
            }

            if (showtime.EndTime.Minute < 10)
            {
                response.StartTime = showtime.StartTime.Hour + ":0" + showtime.StartTime.Minute;
            }
            else
            {
                response.StartTime = showtime.StartTime.Hour + ":" + showtime.StartTime.Minute;
            }


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

        public List<ShowtimeResponse> GetShowtimeByMovie(int movieId)
        {
            var tickets = from m in _dataContext.Movies
                          join t in _dataContext.Tickets on m.Id equals t.Movie.Id
                          where t.Movie.Id == movieId
                          select new
                          {
                              TicketId = t.Id
                          };

            var ticketList = new List<Ticket>();
            foreach (var item in tickets)
            {
                ticketList.Add(_dataContext.Find<Ticket>(item.TicketId));
            }
            var showtimes = new List<ShowtimeResponse>();
            foreach (var item in ticketList)
            {
                var response = new ShowtimeResponse();

                response.Id = item.Showtime.Id;
                if (item.Showtime.EndTime.Minute < 10)
                {
                    response.EndTime = item.Showtime.EndTime.Hour + ":0" + item.Showtime.EndTime.Minute;
                }
                else
                {
                    response.EndTime = item.Showtime.EndTime.Hour + ":" + item.Showtime.EndTime.Minute;
                }

                if (item.Showtime.EndTime.Minute < 10)
                {
                    response.StartTime = item.Showtime.StartTime.Hour + ":0" + item.Showtime.StartTime.Minute;
                }
                else
                {
                    response.StartTime = item.Showtime.StartTime.Hour + ":" + item.Showtime.StartTime.Minute;
                }
                showtimes.Add(response);
            }
            var showtimeList = showtimes.Distinct(new Comparer()).ToList();
            return showtimeList;
        }

        class Comparer : IEqualityComparer<ShowtimeResponse>
        {
            public bool Equals(ShowtimeResponse x, ShowtimeResponse y)
            {
                return x.Id == y.Id &&
                    x.StartTime.ToString().ToLower() == y.StartTime.ToString().ToLower() &&
                    x.EndTime.ToString().ToLower() == y.EndTime.ToString().ToLower();
            }

            public int GetHashCode(ShowtimeResponse obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}

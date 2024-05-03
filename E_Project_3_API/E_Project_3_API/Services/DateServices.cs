using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Project_3_API.Services
{
    public class DateServices : IDateServices
    {
        private readonly DataContext _context;

        public DateServices(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<DateResponse> GetAllDates()
        {
            List<DateResponse> result = new List<DateResponse>();
            var dateList = _context.Set<Models.Date>().ToList();
            foreach ( var date in dateList )
            {
                result.Add(new DateResponse()
                {
                    Id = date.Id,
                    Day = date.Day.Day + "/" + date.Day.Month + "/" + date.Day.Year
                });
            }
            return result;
        }

        public DateResponse GetDateById(int id)
        {
            var date = _context.Find<Models.Date>(id);
            if (date == null)
            {
                throw new Exception();
            }
            var response = new DateResponse()
            {
                Id = date.Id,
                Day = date.Day.Day + "/" + date.Day.Month + "/" + date.Day.Year
            };
            return response;
        }

        public void CreateSomeDates(int dayQty)
        {
            var existedDateList = _context.Set<Models.Date>().ToList();
            for (int i = 0; i < dayQty; i++)
            {
                var newDate = new Models.Date
                {
                    Day = existedDateList.Last().Day.AddDays(1).Date
                };
                _context.Dates.Add(newDate);
                _context.SaveChanges();
            }
        }

        public void CreateDate(DateRequest request)
        {
            var existedDate = _context.Dates.FirstOrDefault(d => d.Day.Date == request.Day.Date);
            if (existedDate == null)
            {
                var newDate = new Models.Date
                {
                    Day = request.Day.Date
                };
                _context.Dates.Add(newDate);
                _context.SaveChanges();
            }
        }

        public void UpdateDate(int id, Models.Date date)
        {
            var existingDate = _context.Dates.FirstOrDefault(d => d.Id == id);
            if (existingDate != null)
            {
                existingDate.Day = date.Day;
                
                _context.SaveChanges();
            }
        }

        public void DeleteDate(int id)
        {
            var dateToDelete = _context.Dates.FirstOrDefault(d => d.Id == id);
            if (dateToDelete != null)
            {
                _context.Dates.Remove(dateToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        public List<DateResponse> GetDateByMovie(int movieId)
        {
            var tickets = from m in _context.Movies
                          join t in _context.Tickets on m.Id equals t.Movie.Id
                          where t.Date.Day >= DateTime.Today.Date && m.Id == movieId
                          select new
                          {
                              TicketId = t.Id
                          };

            var ticketList = new List<Ticket>();
            foreach (var item in tickets)
            {
                ticketList.Add(_context.Find<Ticket>(item.TicketId));
            }
            var dates = new List<DateResponse>();
            foreach (var item in ticketList)
            {
                dates.Add(new DateResponse
                {
                    Id = item.Date.Id,
                    Day = item.Date.Day.Day + "/" + item.Date.Day.Month + "/" + item.Date.Day.Year
                });
            }
            var showtimeList = dates.Distinct(new Comparer()).ToList();
            return showtimeList;
        }

        class Comparer : IEqualityComparer<DateResponse>
        {
            public bool Equals(DateResponse x, DateResponse y)
            {
                return x.Id == y.Id &&
                    x.Day.ToString().ToLower() == y.Day.ToString().ToLower();
            }

            public int GetHashCode(DateResponse obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

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
            var dateList = _context.Set<Date>().ToList();
            foreach ( var date in dateList )
            {
                result.Add(new DateResponse()
                {
                    Id = date.Id,
                    Day = date.Day
                });
            }
            return result;
        }

        public DateResponse GetDateById(int id)
        {
            var date = _context.Find<Date>(id);
            if (date == null)
            {
                throw new Exception();
            }
            var response = new DateResponse()
            {
                Id = date.Id,
                Day = date.Day
            };
            return response;
        }

        public void CreateDate(DateRequest request)
        {
            var existedDate = _context.Dates.FirstOrDefault(d => d.Day.Date == request.Day.Date);
            if (existedDate == null)
            {
                var newDate = new Date
                {
                    Day = request.Day.Date
                };
                _context.Dates.Add(newDate);
                _context.SaveChanges();
            }
        }

        public void UpdateDate(int id, Date date)
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
    }
}

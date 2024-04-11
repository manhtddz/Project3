using System.Collections.Generic;
using System.Linq;
using E_Project_3_API.DTO.Error;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class SeatServices : ISeatServices
    {
        private readonly DataContext _dataContext;

        public SeatServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public SeatsModifyResponse CreateSeat(SeatsRequest request)
        {
            var response = new SeatsModifyResponse();

            var existingSeat = _dataContext.Seats.FirstOrDefault(s => s.Name == request.Name);
            if(request.Name != "")
            {
                if (existingSeat != null)
                {
                    response.Error.ExistedError = "A seat with the same name already exists.";
                    return response;
                }

                var newSeat = new Seat
                {
                    Name = request.Name
                };

                _dataContext.Seats.Add(newSeat);
                _dataContext.SaveChanges();

                response.isModified = true;
                return response;
            }
            else
            {
                response.Error.NameError = "Name is required";
                return response;
            }
        }

        public List<SeatsResponse> GetAllSeats()
        {
            var seats = _dataContext.Seats.ToList();
            var response = new List<SeatsResponse>();

            foreach (var seat in seats)
            {
                var seatResponse = new SeatsResponse
                {
                    Id = seat.Id,
                    Name = seat.Name
                };

                response.Add(seatResponse);
            }
            return response;
        }

        public SeatsResponse GetSeat(int id)
        {
            var seat = _dataContext.Seats.Find(id);

            if (seat == null)
                return null;

            var response = new SeatsResponse
            {
                Id = seat.Id,
                Name = seat.Name
              
            };

            return response;
        }

        public SeatsModifyResponse UpdateSeat(int id, SeatsRequest request)
        {
            var response = new SeatsModifyResponse();

          
            var existingSeat = _dataContext.Seats.Find(id);
            if(request.Name != "")
            {
                if (existingSeat == null)
                {
                    response.Error.ExistedError = "Seat not found.";
                    return response;
                }


                existingSeat.Name = request.Name;

                _dataContext.Update(existingSeat);
                _dataContext.SaveChanges();

                response.isModified = true;
                return response;
            }
            else
            {
                response.Error.NameError = "Name is required";
                return response;
            }
            
        }

        public SeatsModifyResponse DeleteSeat(int id)
        {
            var response = new SeatsModifyResponse();

            
            var seatToDelete = _dataContext.Seats.Find(id);
            if (seatToDelete == null)
            {
                response.Error.ExistedError = "Seat not found.";
                return response;
            }

            _dataContext.Remove(seatToDelete);
            _dataContext.SaveChanges();

            response.isModified = true;
            return response;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class TicketServices : ITicketServices
    {
        private readonly DataContext _dataContext;

        public TicketServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TicketModifyResponse CreateTicket(TicketRequest request)
        {
            var ticketModifyResponse = new TicketModifyResponse();

            var movie = _dataContext.Movies.Find(request.MovieId);
            var theater = _dataContext.Theaters.Find(request.TheaterId);
            var seat = _dataContext.Seats.Find(request.SeatId);
            var showtime = _dataContext.Showtimes.Find(request.ShowtimeId);
            var date = _dataContext.Dates.Find(request.DateId);
            var existedTicket = _dataContext.Tickets.FirstOrDefault(t => 
                t.Movie.Id == request.MovieId &&
                t.Theater.Id == request.TheaterId &&
                t.Seat.Id == request.SeatId &&
                t.Showtime.Id == request.ShowtimeId &&
                t.Date.Id == request.DateId
            );
            if (movie != null && theater != null && showtime != null && date != null && seat != null)
            {
                if (existedTicket != null)
                {
                    ticketModifyResponse.Error.NotFoundErrorMessage = "Can't create ticket with same details";
                    return ticketModifyResponse;
                }
                var newTicket = new Ticket
                {
                    Movie = movie,
                    Theater = theater,
                    Seat = seat,
                    Showtime = showtime,
                    Date = date
                };

                _dataContext.Tickets.Add(newTicket);
                _dataContext.SaveChanges();

                ticketModifyResponse.isModified = true;
                return ticketModifyResponse;
                
            }
            else
            {
                ticketModifyResponse.Error.NotFoundErrorMessage = "One or more specified entities not found";

                return ticketModifyResponse;
            }
            
        }

        public List<TicketResponse> GetAllTickets()
        {
            var tickets = _dataContext.Tickets.ToList();
            var response = new List<TicketResponse>();
            foreach (var item in tickets)
            {
                response.Add(Convert(item));
            }
            return response;
        }

        public TicketResponse GetTicketById(int id)
        {
            var ticket = _dataContext.Tickets.Find(id);
            if (ticket == null)
            {
                return null;
            }
            return Convert(ticket);
        }

        public TicketModifyResponse UpdateTicket(int id, TicketRequest request)
        {
            var ticketModifyResponse = new TicketModifyResponse();
            var existedTicket = _dataContext.Find<Ticket>(id);
            var movie = _dataContext.Movies.Find(request.MovieId);
            var theater = _dataContext.Theaters.Find(request.TheaterId);
            var seat = _dataContext.Seats.Find(request.SeatId);
            var showtime = _dataContext.Showtimes.Find(request.ShowtimeId);
            var date = _dataContext.Dates.Find(request.DateId);

            if (movie != null && theater != null && showtime != null && date != null && seat != null)
            {
                if (existedTicket == null)
                {
                    ticketModifyResponse.Error.NotFoundErrorMessage = "Ticket not found";
                    return ticketModifyResponse;
                }
                var newTicket = new Ticket
                {
                    Movie = movie,
                    Theater = theater,
                    Seat = seat,
                    Showtime = showtime,
                    Date = date
                };
                _dataContext.Tickets.Update(newTicket);
                _dataContext.SaveChanges();

                ticketModifyResponse.isModified = true;
                return ticketModifyResponse;
            }
            else
            {
                ticketModifyResponse.Error.NotFoundErrorMessage = "One or more specified entities not found";

                return ticketModifyResponse;
            }
        }

        public TicketModifyResponse DeleteTicket(int id)
        {
            var ticket = _dataContext.Tickets.Find(id);
            var response = new TicketModifyResponse();
            if (ticket == null)
            {
                response.Error.NotFoundErrorMessage = "Ticket not found";
                return response;
            }
            _dataContext.Remove<Ticket>(ticket);
            _dataContext.SaveChanges();
            response.isModified = true;
            return response;
        }


        private TicketResponse Convert(Ticket ticket)
        {
            var ticketResponse = new TicketResponse
            {
                Id = ticket.Id,
                Active = ticket.Active,
                MovieId = ticket.Movie.Id,
                TheaterId = ticket.Theater.Id,
                SeatId = ticket.Seat.Id,
                ShowtimeId = ticket.Showtime.Id,
                DateId = ticket.Date.Id
            };
            if (ticket.User != null)
            {
                ticketResponse.UserId = ticket.User.Id;
            }
            return ticketResponse;
        }
    }
}

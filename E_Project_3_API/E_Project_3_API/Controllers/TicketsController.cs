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
    public class TicketsController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;

        public TicketsController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpPost()]
        public IActionResult CreateTicket(TicketRequest request)
        {
            var response = _ticketServices.CreateTicket(request);
            return Ok(response);
        }

        [HttpGet()]
        public IActionResult GetAllTickets()
        {
            var response = _ticketServices.GetAllTickets();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            var response = _ticketServices.GetTicketById(id);
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

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, TicketRequest request)
        {
            var response = _ticketServices.UpdateTicket(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var response = _ticketServices.DeleteTicket(id);
            return Ok(response);
        }
        [HttpGet("{movieId}/{dateId}/{showtimeId}")]
        public IActionResult GetTicketByMovieDateShowtime(int movieId, int dateId, int showtimeId)
        {
            var result = _ticketServices.GetTicketByMovieDateShowtime(movieId, dateId, showtimeId);
            return Ok(result);
        }
        [HttpGet("{movieId}")]
        public IActionResult GetTicketByMovie(int movieId)
        {
            var result = _ticketServices.GetTicketByMovie(movieId);
            return Ok(result);
        }
        [HttpGet("{movieId}/{startIndex}/{limit}")]
        public IActionResult GetTicketPagingByMovie(int movieId, int startIndex, int limit)
        {
            var result = _ticketServices.GetTicketPagingByMovie(movieId, startIndex, limit);
            return Ok(result);
        }
        [HttpGet("{movieId}")]
        public IActionResult GetLengthOfTicketsByMovie(int movieId)
        {
            var result = _ticketServices.GetTicketByMovie(movieId).Count();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult BookingTicket(int id, UserRequest request)
        {
            var result = _ticketServices.BookingTicket(id, request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult TotalIncome()
        {
            return Ok(_ticketServices.TotalIncome());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.Models;
using E_Project_3_API.Services;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DatesController : ControllerBase
    {
        private readonly IDateServices _dateService;

        public DatesController(IDateServices dateService)
        {
            _dateService = dateService;
        }

        [HttpGet]
        public IActionResult GetAllDates()
        {
            var dates = _dateService.GetAllDates();
            return Ok(dates);
        }

        [HttpGet("{id}")]
        public IActionResult GetDateById(int id)
        {
            try
            {
                var result = _dateService.GetDateById(id);
                return Ok(result);
            }
            catch
            {
                return NotFound(new
                {
                    isGet = false,
                    message = "Not Found"
                }); 
            }
        }

        [HttpPost]
        public IActionResult CreateDate(DateRequest request)
        {
            _dateService.CreateDate(request);
            return Ok(request);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateDate(int id, [FromBody] DateRequest dateDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingDate = _dateService.GetDateById(id);
        //    if (existingDate == null)
        //    {
        //        return NotFound();
        //    }

        //    existingDate.Day = dateDto.Day;
           
        //    _dateService.UpdateDate(id, existingDate);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteDate(int id)
        {
            try
            {
                _dateService.DeleteDate(id);
                return Ok("Delete success");
            }
            catch
            {
                return Ok("Not found");
            }
        }
    }
}

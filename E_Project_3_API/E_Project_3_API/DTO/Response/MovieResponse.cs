using System.ComponentModel.DataAnnotations;
using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true;
    }

    public class MovieModifyResponse
    {
        public bool isModified { get; set; } = false;
        public MovieError Error { get; set; } = new MovieError();
    }
}

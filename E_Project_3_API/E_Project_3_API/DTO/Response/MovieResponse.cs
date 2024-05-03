using System.ComponentModel.DataAnnotations;
using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShopName { get; set; }
        public int ShopId { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true;
    }

    public class MovieModifyResponse
    {
        public bool isModified { get; set; } = false;
        public MovieError Error { get; set; } = new MovieError();
    }
}

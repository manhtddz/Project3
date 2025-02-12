using System.ComponentModel.DataAnnotations;
using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class GenreResponse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }

    public class GenreModifyResponse
    {
        public bool isModified { get; set; } = false;
        public GenreError Error { get; set; } = new GenreError();
        
    }
}

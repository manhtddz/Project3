using System.ComponentModel.DataAnnotations;
using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public bool Active { get; set; }
    }

    public class CategoryModifyResponse
    {
        public bool isModified { get; set; } = false;
        public CategoryError Error { get; set; } = new CategoryError();
    }
}

using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.DTO.Response
{
    public class TypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
    }

    public class TypeModifyResponse
    {
        public bool isModified { get; set; } = false;
        public TypeError Error { get; set; } = new TypeError();
    }
}

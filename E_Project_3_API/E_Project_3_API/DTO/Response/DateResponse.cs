using System.ComponentModel.DataAnnotations;
using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class DateResponse
    {
        public int Id { get; set; }
        public string Day { get; set; }
        
    }

    public class DateModifyResponse
    {
        public bool isModified { get; set; } = false;
        public DateError Error { get; set; } = new DateError();
    }
}

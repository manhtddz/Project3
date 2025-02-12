using System.ComponentModel.DataAnnotations;

namespace E_Project_3_API.DTO
{
    public class ShopError
    {
        public string ExistedError { get; set; } = "";
        public string NameError { get; set; } = "";
        public string LogoError { get; set; } = "";
        public string PhoneError { get; set; } = "";
        public string EmailError { get; set; } = "";
        public string AddressError { get; set; } = "";
    }
}

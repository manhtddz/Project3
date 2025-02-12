namespace E_Project_3_API.DTO.Request
{
    public class ProductRequest
    {
        public int CateId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
       
    }
}

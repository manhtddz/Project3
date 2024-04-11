namespace E_Project_3_API.DTO.Response
{
    public class ShopResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        }

    public class ShopModifyResponse
    {
        public bool isModified { get; set; } = false;
        public ShopError Error { get; set; } = new ShopError();
    }
}

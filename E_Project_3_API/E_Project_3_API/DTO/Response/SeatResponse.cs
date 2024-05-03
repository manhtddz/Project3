using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class SeatsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }

    public class SeatsModifyResponse
    {
        public bool isModified { get; set; } = false;
        public SeatsError Error { get; set; } = new SeatsError();
    }
}

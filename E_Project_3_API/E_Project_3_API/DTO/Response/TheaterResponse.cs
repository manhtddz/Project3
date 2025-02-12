using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class TheaterResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        
    }

    public class TheaterModifyResponse
    {
        public bool isModified { get; set; } = false;
        public TheaterError Error { get; set; } = new TheaterError();
    }
}

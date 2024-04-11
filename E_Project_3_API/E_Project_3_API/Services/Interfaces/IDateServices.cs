using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IDateServices
    {
        IEnumerable<DateResponse> GetAllDates();
        DateResponse GetDateById(int id);
        void CreateDate(DateRequest date);
        void UpdateDate(int id, Date date);
        void DeleteDate(int id);
    }
}

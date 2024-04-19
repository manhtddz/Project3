using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;

namespace E_Project_3_API.Services.Interfaces
{
    public interface ITypeServices
    {
        List<TypeResponse> GetAllTypes();
        TypeResponse GetType(int id);
        TypeModifyResponse CreateType(TypeRequest request);
        TypeModifyResponse DeleteType(int id);
        TypeModifyResponse UpdateType(int id, TypeRequest request);
        List<TypeResponse> GetPagingTypes(int startIndex, int limit);
    }
}

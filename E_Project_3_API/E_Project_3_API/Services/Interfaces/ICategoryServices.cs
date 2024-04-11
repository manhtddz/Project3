using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface ICategoryServices
    {
        List<CategoryResponse> GetAllCategories();
        CategoryResponse GetCategory(int id);
        CategoryModifyResponse CreateCategory(CategoryRequest request);
        CategoryModifyResponse DeleteCategory(int id);
        CategoryModifyResponse UpdateCategory(int id, CategoryRequest request);
    }
}

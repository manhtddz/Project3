using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IProductServices
    {
        List<ProductResponse> GetAllProducts();
        ProductResponse GetProduct(int id);
        ProductModifyResponse CreateProduct(ProductRequest request);
        ProductModifyResponse UpdateProduct(int id, ProductRequest request);
        ProductModifyResponse DeleteProduct(int id);
        List<ProductResponse> GetPagingProducts(int startIndex, int limit);
        List<ProductResponse> GetAllProductsByType(int typeId);
        List<ProductResponse> GetPagingProductsByType(int typeId, int startIndex, int limit);
        List<ProductResponse> GetAllSearchProductsByType(int typeId, string searchText);
        List<ProductResponse> GetPagingSearchProductsByType(int typeId, int startIndex, int limit, string searchText);
    }
}

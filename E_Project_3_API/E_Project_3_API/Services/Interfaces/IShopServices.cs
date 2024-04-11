using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;

namespace E_Project_3_API.Services.Interfaces
{
    public interface IShopServices
    {
        List<ShopResponse> GetAllShops();
        ShopResponse GetShop(int id);
        ShopModifyResponse CreateShop(ShopRequest request);
        ShopModifyResponse DeleteShop(int id);
        ShopModifyResponse UpdateShop(int id, ShopRequest request);
    }
}

using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using E_Project_3_API.Services.Utility;

namespace E_Project_3_API.Services
{
    public class ShopServices : IShopServices
    {
        private readonly DataContext _dataContext;

        public ShopServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ShopResponse Convert(Shop shop)
        {
            var shopResponse = new ShopResponse()
            {
                Id = shop.Id,
                Name = shop.Name,
                Logo = shop.Logo,
                Description = shop.Description,
                Address = shop.Address,
                Email = shop.Email,
                Phone = shop.Phone,
                Active = shop.Active
            };
            return shopResponse;
        }

        public ShopModifyResponse CreateShop(ShopRequest request)
        {
            var shopModifyResponse = new ShopModifyResponse();
            var existedShop = GetAllShops().SingleOrDefault(t => t.Name == request.Name || t.Email == request.Email);
            if (request.Name != "" && request.Logo != "" && request.Email != "" && request.Phone != "" && request.Address != "")
            {
                if (existedShop != null)
                {
                    shopModifyResponse.Error.ExistedError = "Shop is existed";
                    return shopModifyResponse;
                }
                if (!RegexManagement.IsEmail(request.Email) || !RegexManagement.IsPhoneNumber(request.Phone))
                {
                    if (!RegexManagement.IsEmail(request.Email))
                    {
                        shopModifyResponse.Error.EmailError = "Email is rejected";
                    }
                    if (!RegexManagement.IsPhoneNumber(request.Phone))
                    {
                        shopModifyResponse.Error.PhoneError = "Phone number is rejected";
                    }
                    return shopModifyResponse;
                }

                var newShop = new Shop()
                {
                    Name = request.Name,
                    Logo = request.Logo,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    Description = request.Description
                };
                _dataContext.Add(newShop);
                _dataContext.SaveChanges();
                shopModifyResponse.isModified = true;
                return shopModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    shopModifyResponse.Error.NameError = "Name is required";
                }
                if (request.Logo == "")
                {
                    shopModifyResponse.Error.LogoError = "LogoUrl is required";
                }
                if (request.Email == "")
                {
                    shopModifyResponse.Error.EmailError = "Email is required";
                }
                if (request.Phone == "")
                {
                    shopModifyResponse.Error.PhoneError = "Phone is required";
                }
                if (request.Address == "")
                {
                    shopModifyResponse.Error.AddressError = "Address is required";
                }
                return shopModifyResponse;
            }
        }

        public ShopModifyResponse DeleteShop(int id)
        {
            var shopModifyResponse = new ShopModifyResponse();
            var shopToDelete = _dataContext.Shops.Find(id);
            if (shopToDelete == null)
            {
                shopModifyResponse.Error.ExistedError = "Shop not found.";
                return shopModifyResponse;
            }

            _dataContext.Shops.Remove(shopToDelete);
            _dataContext.SaveChanges();

            shopModifyResponse.isModified = true;
            return shopModifyResponse;
        }

        public List<ShopResponse> GetAllShops()
        {
            var shops = _dataContext.Shops.ToList();
            var responses = new List<ShopResponse>();
            foreach (var shop in shops)
            {
                responses.Add(Convert(shop));
            }
            return responses;
        }

        public ShopResponse GetShop(int id)
        {
            var shop = _dataContext.Shops.Find(id);
            if (shop == null)
            {
                return null;
            }
            var response = Convert(shop);
            return response;
        }

        public ShopModifyResponse UpdateShop(int id, ShopRequest request)
        {
            var shopModifyResponse = new ShopModifyResponse();
            var existingShop = _dataContext.Shops.Find(id);
            if(request.Name != "" && request.Email != "" && request.Logo != "" && request.Phone != "" && request.Address != "")
            {
                if (existingShop == null)
                {
                    shopModifyResponse.Error.ExistedError = "Shop not found.";
                    return shopModifyResponse;
                }
                if (!RegexManagement.IsEmail(request.Email) || !RegexManagement.IsPhoneNumber(request.Phone))
                {
                    if (!RegexManagement.IsEmail(request.Email))
                    {
                        shopModifyResponse.Error.EmailError = "Email is rejected";
                    }
                    if (!RegexManagement.IsPhoneNumber(request.Phone))
                    {
                        shopModifyResponse.Error.PhoneError = "Phone number is rejected";
                    }
                    return shopModifyResponse;
                }
                existingShop.Name = request.Name;
                existingShop.Description = request.Description;
                existingShop.Logo = request.Logo;
                existingShop.Phone = request.Phone;
                existingShop.Email = request.Email;
                existingShop.Address = request.Address;

                _dataContext.Update<Shop>(existingShop);
                _dataContext.SaveChanges();

                shopModifyResponse.isModified = true;
                return shopModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    shopModifyResponse.Error.NameError = "Name is required";
                }
                if (request.Logo == "")
                {
                    shopModifyResponse.Error.LogoError = "LogoUrl is required";
                }
                if (request.Email == "")
                {
                    shopModifyResponse.Error.EmailError = "Email is required";
                }
                if (request.Phone == "")
                {
                    shopModifyResponse.Error.PhoneError = "Phone is required";
                }
                if (request.Address == "")
                {
                    shopModifyResponse.Error.AddressError = "Address is required";
                }
                return shopModifyResponse;
            }
        }

        public List<ShopResponse> GetPagingShops(int startIndex, int limit)
        {
            var shops = _dataContext.Set<Shop>().ToList();

            var responses = new List<ShopResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= shops.Count)
                {
                    break;
                }
                responses.Add(Convert(shops[i]));
            }
            return responses;
        }
    }
}

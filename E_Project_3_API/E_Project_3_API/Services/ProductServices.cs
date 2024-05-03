using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using E_Project_3_API.DTO.Error;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class ProductServices : IProductServices
    {
        private readonly DataContext _dataContext;

        public ProductServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ProductModifyResponse CreateProduct(ProductRequest request)
        {
            var response = new ProductModifyResponse();

            var existedProduct = _dataContext.Products.FirstOrDefault(p => p.Name == request.Name);
            var existedCategory = _dataContext.Find<Category>(request.CateId);
            var existedShop = _dataContext.Find<Shop>(request.ShopId);
            if (request.Image != "" && request.Name != "" && request.Price != 0 && existedCategory != null && existedShop != null)
            {
                if (existedProduct != null)
                {
                    response.Error.ExistedError = "A product with the same name has already existed.";
                    return response;
                }
                var newProduct = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Image = request.Image,
                    Price = request.Price,
                    Category = existedCategory,
                    Shop = existedShop,
                    Active = true
                };
                _dataContext.Add(newProduct);
                _dataContext.SaveChanges();
                response.isModified = true;
                return response;
            }
            else
            {
                if (request.Name == "")
                {
                    response.Error.NameError = "Name is required";
                }
                if (request.Image == "")
                {
                    response.Error.ImageError = "ImgUrl is required";
                }
                if (existedShop == null)
                {
                    response.Error.ShopError = "Shop is not existed";
                }
                if (existedCategory == null)
                {
                    response.Error.CategoryError = "Category is not existed";
                }
                if (request.Price == 0)
                {
                    response.Error.PriceError = "Price is required to be set";
                }
                return response;
            }
        }

        public ProductModifyResponse DeleteProduct(int id)
        {
            var response = new ProductModifyResponse();


            var productToDelete = _dataContext.Products.Find(id);
            if (productToDelete == null)
            {
                response.Error.ExistedError = "Product not found.";
                return response;
            }

            _dataContext.Products.Remove(productToDelete);
            _dataContext.SaveChanges();

            response.isModified = true;
            return response;
        }

        public List<ProductResponse> GetAllProducts()
        {
            var products = _dataContext.Products.ToList();
            var response = new List<ProductResponse>();

            foreach (var product in products)
            {
                var productResponse = new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    ShopName = product.Shop.Name,
                    ShopId = product.Shop.Id,
                    CategoryName = product.Category.Name,
                    CategoryId = product.Category.Id,
                    Active = product.Active
                };

                response.Add(productResponse);
            }

            return response;
        }

        public ProductResponse GetProduct(int id)
        {
            var product = _dataContext.Products.Find(id);

            if (product == null)
                return null;

            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                ShopName = product.Shop.Name,
                ShopId = product.Shop.Id,
                CategoryName = product.Category.Name,
                CategoryId = product.Category.Id,
                Active = product.Active
            };

            return response;
        }

        public ProductModifyResponse UpdateProduct(int id, ProductRequest request)
        {
            var response = new ProductModifyResponse();


            var existedProduct = _dataContext.Find<Product>(id);
            var existedCategory = _dataContext.Find<Category>(request.CateId);
            var existedShop = _dataContext.Find<Shop>(request.ShopId);
            if (request.Image != "" && request.Name != "" && request.Price != 0 && existedCategory != null && existedShop != null)
            {
                if (existedProduct == null)
                {
                    response.Error.ExistedError = "Product not found.";
                    return response;
                }
                existedProduct.Name = request.Name;
                existedProduct.Description = request.Description;
                existedProduct.Image = request.Image;
                existedProduct.Price = request.Price;
                existedProduct.Shop = existedShop;
                existedProduct.Category = existedCategory;

                _dataContext.SaveChanges();

                response.isModified = true;
                return response;
            }
            else
            {
                if (request.Name == "")
                {
                    response.Error.NameError = "Name is required";
                }
                if (request.Image == "")
                {
                    response.Error.ImageError = "ImgUrl is required";
                }
                if (existedShop == null)
                {
                    response.Error.ShopError = "Shop is not existed";
                }
                if (existedCategory == null)
                {
                    response.Error.CategoryError = "Category is not existed";
                }
                if (request.Price == 0)
                {
                    response.Error.PriceError = "Price is required to be set";
                }
                return response;
            }
        }
        public List<ProductResponse> GetPagingProducts(int startIndex, int limit)
        {
            var products = _dataContext.Set<Product>().ToList();

            var responses = new List<ProductResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= products.Count)
                {
                    break;
                }
                responses.Add(new ProductResponse
                {
                    Id = products[i].Id,
                    Name = products[i].Name,
                    Description = products[i].Description,
                    Image = products[i].Image,
                    Price = products[i].Price,
                    ShopName = products[i].Shop.Name,
                    ShopId = products[i].Shop.Id,
                    CategoryName = products[i].Category.Name,
                    CategoryId = products[i].Category.Id,
                    Active = products[i].Active
                });
            }
            return responses;
        }
        public List<ProductResponse> GetAllProductsByType(int typeId)
        {
            var products = from t in _dataContext.Types
                           join c in _dataContext.Categories on t.Id equals c.Type.Id
                           join p in _dataContext.Products on c.Id equals p.Category.Id
                           where t.Id == typeId
                           select new
                           {
                               ProductId = p.Id,
                           };
            var takenProducts = new List<Product>();
            var responses = new List<ProductResponse>();

            foreach (var item in products)
            {
                takenProducts.Add(_dataContext.Find<Product>(item.ProductId));
            }
            foreach (var item in takenProducts)
            {
                responses.Add(new ProductResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    ShopName = item.Shop.Name,
                    ShopId = item.Shop.Id,
                    CategoryName = item.Category.Name,
                    CategoryId = item.Category.Id,
                    Active = item.Active
                });
            }
            return responses;
        }
        public List<ProductResponse> GetPagingProductsByType(int typeId, int startIndex, int limit)
        {
            var products = from t in _dataContext.Types
                           join c in _dataContext.Categories on t.Id equals c.Type.Id
                           join p in _dataContext.Products on c.Id equals p.Category.Id
                           where t.Id == typeId
                           select new
                           {
                               ProductId = p.Id,
                           };
            var takenProducts = new List<Product>();
            var responses = new List<ProductResponse>();

            foreach (var item in products)
            {
                takenProducts.Add(_dataContext.Find<Product>(item.ProductId));
            }
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= takenProducts.Count)
                {
                    break;
                }
                responses.Add(new ProductResponse
                {
                    Id = takenProducts[i].Id,
                    Name = takenProducts[i].Name,
                    Description = takenProducts[i].Description,
                    Image = takenProducts[i].Image,
                    Price = takenProducts[i].Price,
                    ShopName = takenProducts[i].Shop.Name,
                    ShopId = takenProducts[i].Shop.Id,
                    CategoryName = takenProducts[i].Category.Name,
                    CategoryId = takenProducts[i].Category.Id,
                    Active = takenProducts[i].Active
                });
            }
            return responses;
        }
        public List<ProductResponse> GetAllSearchProductsByType(int typeId, string searchText)
        {
            var products = from t in _dataContext.Types
                           join c in _dataContext.Categories on t.Id equals c.Type.Id
                           join p in _dataContext.Products on c.Id equals p.Category.Id
                           where t.Id == typeId && (p.Name.Contains(searchText)
                           || p.Shop.Name.Contains(searchText)
                           || p.Category.Name.Contains(searchText))
                           select new
                           {
                               ProductId = p.Id,
                           };
            var takenProducts = new List<Product>();
            var responses = new List<ProductResponse>();

            foreach (var item in products)
            {
                takenProducts.Add(_dataContext.Find<Product>(item.ProductId));
            }
            foreach (var item in takenProducts)
            {
                responses.Add(new ProductResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    ShopName = item.Shop.Name,
                    ShopId = item.Shop.Id,
                    CategoryName = item.Category.Name,
                    CategoryId = item.Category.Id,
                    Active = item.Active
                });
            }
            return responses;
        }

        public List<ProductResponse> GetPagingSearchProductsByType(int typeId, int startIndex, int limit, string searchText)
        {
            var products = from t in _dataContext.Types
                           join c in _dataContext.Categories on t.Id equals c.Type.Id
                           join p in _dataContext.Products on c.Id equals p.Category.Id
                           where t.Id == typeId && (p.Name.Contains(searchText)
                           || p.Shop.Name.Contains(searchText)
                           || p.Category.Name.Contains(searchText))
                           select new
                           {
                               ProductId = p.Id,
                           };
            var takenProducts = new List<Product>();
            var responses = new List<ProductResponse>();

            foreach (var item in products)
            {
                takenProducts.Add(_dataContext.Find<Product>(item.ProductId));
            }
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= takenProducts.Count)
                {
                    break;
                }
                responses.Add(new ProductResponse
                {
                    Id = takenProducts[i].Id,
                    Name = takenProducts[i].Name,
                    Description = takenProducts[i].Description,
                    Image = takenProducts[i].Image,
                    Price = takenProducts[i].Price,
                    ShopName = takenProducts[i].Shop.Name,
                    ShopId = takenProducts[i].Shop.Id,
                    CategoryName = takenProducts[i].Category.Name,
                    CategoryId = takenProducts[i].Category.Id,
                    Active = takenProducts[i].Active
                });
            }
            return responses;
        }
    }
}

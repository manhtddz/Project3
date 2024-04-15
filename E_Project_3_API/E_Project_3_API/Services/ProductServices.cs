using System;
using System.Collections.Generic;
using System.Linq;
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
        
    }
}

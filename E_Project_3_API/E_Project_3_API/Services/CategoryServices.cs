﻿using Azure;
using Azure.Core;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly DataContext _dataContext;
        public CategoryServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CategoryResponse Convert(Category category)
        {
            var categoryResponse = new CategoryResponse()
            {
                Id = category.Id,
                Name = category.Name,
                TypeId = category.Type.Id,
                TypeName = category.Type.Name,
                Active = category.Active
            };
            return categoryResponse;
        }

        public CategoryModifyResponse CreateCategory(CategoryRequest request)
        {
            var categoryModifyResponse = new CategoryModifyResponse();
            var existedType = _dataContext.Find<Models.Type>(request.TypeId);
            var existedCategory = GetAllCategories().SingleOrDefault(t => t.Name == request.Name);
            if (request.Name != "" && existedType != null)
            {
                if (existedCategory != null)
                {
                    categoryModifyResponse.Error.ExistedError = "Category is existed";
                    return categoryModifyResponse;
                }
                
                var newCategory = new Category()
                {
                    Name = request.Name,
                    Type = existedType
                };
                _dataContext.Add(newCategory);
                _dataContext.SaveChanges();
                categoryModifyResponse.isModified = true;
                return categoryModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    categoryModifyResponse.Error.NameError = "Name is required";
                }
                if (existedType == null)
                {
                    categoryModifyResponse.Error.TypeError = "Type is not existed";
                }
                return categoryModifyResponse;
            }
        }

        public CategoryModifyResponse DeleteCategory(int id)
        {
            var categoryModifyResponse = new CategoryModifyResponse();
            var existedCategory = _dataContext.Find<Category>(id);
            if(existedCategory == null)
            {
                categoryModifyResponse.Error.ExistedError = "Category is not existed";
                return categoryModifyResponse;
            }
            _dataContext.Remove<Category>(existedCategory);
            _dataContext.SaveChanges();
            categoryModifyResponse.isModified = true;
            return categoryModifyResponse;
        }

        public List<CategoryResponse> GetAllCategories()
        {
            var categories = _dataContext.Set<Category>().ToList();
            var responses = new List<CategoryResponse>();
            foreach (var category in categories)
            {
                responses.Add(Convert(category));
            }
            return responses;
        }

        public CategoryResponse GetCategory(int id)
        {
            var category = _dataContext.Find<Category>(id);
            if (category == null)
            {
                throw new Exception();
            }
            return Convert(category);
        }

        public CategoryModifyResponse UpdateCategory(int id, CategoryRequest request)
        {
            var categoryModifyResponse = new CategoryModifyResponse();
            var existedType = _dataContext.Find<Models.Type>(request.TypeId);
            var existedCategory = _dataContext.Find<Category>(id);
            if (request.Name != "" &&  existedType != null)
            {
                if (existedCategory == null)
                {
                    categoryModifyResponse.Error.ExistedError = "Category is not existed";
                    return categoryModifyResponse;
                }
                existedCategory.Name = request.Name;
                existedCategory.Type = existedType;
                _dataContext.Update(existedCategory);
                _dataContext.SaveChanges();
                categoryModifyResponse.isModified = true;
                return categoryModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    categoryModifyResponse.Error.NameError = "Name is required";
                }
                if (existedType == null)
                {
                    categoryModifyResponse.Error.TypeError = "Type is not existed";
                }
                return categoryModifyResponse;
            }
        }
        public List<CategoryResponse> GetPagingCategories(int startIndex, int limit)
        {
            var categories = _dataContext.Set<Category>().ToList();

            var responses = new List<CategoryResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= categories.Count)
                {
                    break;
                }
                responses.Add(Convert(categories[i]));
            }
            return responses;
        }
    }
}

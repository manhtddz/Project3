using Azure;
using Azure.Core;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class TypeServices : ITypeServices
    {
        private readonly DataContext _dataContext;
        public TypeServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TypeResponse Convert(Models.Type type)
        {
            var typeResponse = new TypeResponse()
            {
                Id = type.Id,
                Name = type.Name,
                Image = type.Image,
                Active = type.Active
            };
            return typeResponse;
        }

        public TypeModifyResponse CreateType(TypeRequest request)
        {
            var typeModifyResponse = new TypeModifyResponse();
            var existedType = GetAllTypes().SingleOrDefault(t => t.Name == request.Name);
            if (request.Name != "" && request.Image != "")
            {
                if (existedType != null)
                {
                    typeModifyResponse.Error.ExistedError = "Type is existed";
                    return typeModifyResponse;
                }
                var newType = new Models.Type()
                {
                    Name = request.Name,
                    Image = request.Image
                };
                _dataContext.Add(newType);
                _dataContext.SaveChanges();
                typeModifyResponse.isModified = true;
                return typeModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    typeModifyResponse.Error.NameError = "Name is required";
                }
                if(request.Image == "")
                {
                    typeModifyResponse.Error.ImageError = "ImgUrl is required";
                }
                return typeModifyResponse;
            }
        }

        public TypeModifyResponse DeleteType(int id)
        {
            var typeModifyResponse = new TypeModifyResponse();
            var existedType = _dataContext.Find<Models.Type>(id);
            if(existedType == null)
            {
                typeModifyResponse.Error.ExistedError = "Type is not existed";
                return typeModifyResponse;
            }
            _dataContext.Remove<Models.Type>(existedType);
            _dataContext.SaveChanges();
            typeModifyResponse.isModified = true;
            return typeModifyResponse;
        }

        public List<TypeResponse> GetAllTypes()
        {
            var types = _dataContext.Set<Models.Type>().ToList();
            var responses = new List<TypeResponse>();
            foreach (var type in types)
            {
                responses.Add(Convert(type));
            }
            return responses;
        }

        public TypeResponse GetType(int id)
        {
            var type = _dataContext.Find<Models.Type>(id);
            if (type == null)
            {
                throw new Exception();
            }
            return Convert(type);
        }

        public TypeModifyResponse UpdateType(int id, TypeRequest request)
        {
            var typeModifyResponse = new TypeModifyResponse();
            var existedType = _dataContext.Find<Models.Type>(id);
            if (request.Name != "" && request.Image != "")
            {
                if (existedType == null)
                {
                    typeModifyResponse.Error.ExistedError = "Type is not existed";
                    return typeModifyResponse;
                }
                existedType.Name = request.Name;
                existedType.Image = request.Image;
                _dataContext.Update(existedType);
                _dataContext.SaveChanges();
                typeModifyResponse.isModified = true;
                return typeModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    typeModifyResponse.Error.NameError = "Name is required";
                }
                if(request.Image == "")
                {
                    typeModifyResponse.Error.ImageError = "ImgUrl is required";
                }
                return typeModifyResponse;
            }
        }

        public List<TypeResponse> GetPagingTypes(int startIndex, int limit)
        {
            var types = _dataContext.Set<Models.Type>().ToList();

            var responses = new List<TypeResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= types.Count)
                {
                    break;
                }
                responses.Add(Convert(types[i]));
            }
            return responses;
        }
    }
}

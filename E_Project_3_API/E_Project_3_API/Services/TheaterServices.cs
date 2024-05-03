using System.Collections.Generic;
using System.Linq;
using E_Project_3_API.DTO.Error;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class TheaterServices : ITheaterServices
    {
        private readonly DataContext _dataContext;

        public TheaterServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TheaterModifyResponse CreateTheater(TheaterRequest request)
        {
            var response = new TheaterModifyResponse();
            var existedTheater = _dataContext.Theaters.FirstOrDefault(t => t.Name == request.Name);
            if(request.Name != "")
            {
                if(existedTheater != null)
                {
                    response.Error.ExistedError = "Theater is existed";
                    response.isModified = false;
                    return response;
                }
                var newTheater = new Theater
                {
                    Name = request.Name
                };

                _dataContext.Theaters.Add(newTheater);
                _dataContext.SaveChanges();

                response.isModified = true;
                return response;
            }
            else
            {
                response.Error.NameError = "Name is required";
                return response;
            }
            
        }

        public List<TheaterResponse> GetAllTheaters()
        {
            var theaters = _dataContext.Theaters.ToList();
            var response = new List<TheaterResponse>();

            foreach (var theater in theaters)
            {
                var theaterResponse = new TheaterResponse
                {
                    Id = theater.Id,
                    Name = theater.Name,
                    Active = theater.Active
                };

                response.Add(theaterResponse);
            }

            return response;
        }

        public TheaterResponse GetTheater(int id)
        {
            var theater = _dataContext.Theaters.Find(id);
            if (theater == null)
            {
                return null;
            }

            var response = new TheaterResponse
            {
                Id = theater.Id,
                Name = theater.Name,
                Active = theater.Active
            };

            return response;
        }

        public TheaterModifyResponse UpdateTheater(int id, TheaterRequest request)
        {
            var response = new TheaterModifyResponse();


            var existedTheater = _dataContext.Theaters.Find(id);
            if (request.Name != "")
            {
                if (existedTheater == null)
                {
                    response.Error.ExistedError = "Theater not found.";
                    return response;
                }


                existedTheater.Name = request.Name;

                _dataContext.Update(existedTheater);
                _dataContext.SaveChanges();

                response.isModified = true;
                return response;
            }
            else
            {
                response.Error.NameError = "Name is required";
                return response;
            }
        }

        public TheaterModifyResponse DeleteTheater(int id)
        {
            var response = new TheaterModifyResponse();


            var theaterToDelete = _dataContext.Theaters.Find(id);
            if (theaterToDelete == null)
            {
                response.Error.ExistedError = "Theater not found.";
                return response;
            }

            _dataContext.Remove(theaterToDelete);
            _dataContext.SaveChanges();

            response.isModified = true;
            return response;
        }
        public List<TheaterResponse> GetPagingTheaters(int startIndex, int limit)
        {
            var theaters = _dataContext.Set<Theater>().ToList();

            var responses = new List<TheaterResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= theaters.Count)
                {
                    break;
                }
                responses.Add(new TheaterResponse
                {
                    Id = theaters[i].Id,
                    Name = theaters[i].Name,
                    Active = theaters[i].Active
                });
            }
            return responses;
        }
    }
}

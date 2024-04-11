using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;

namespace E_Project_3_API.Services
{
    public class GenreServices : IGenreServices
    {
        private readonly DataContext _context;

        public GenreServices(DataContext context)
        {
            _context = context;
        }
        public GenreResponse Convert(Genre genre)
        {
            var genreResponse = new GenreResponse()
            {
                Id = genre.Id,
                Name = genre.Name
            };
            return genreResponse;
        }
        public List<GenreResponse> GetAllGenres()
        {
            var genres = _context.Set<Genre>().ToList();
            var responses = new List<GenreResponse>();
            foreach (var genre in genres)
            {
                responses.Add(Convert(genre));
            }
            return responses;
        }

        public GenreResponse GetGenreById(int id)
        {
            var genre = _context.Find<Genre>(id);
            if(genre == null)
            {
                return null;
            }
            return Convert(genre);
        }

        public GenreModifyResponse CreateGenre(GenreRequest request)
        {
            var genreModifyResponse = new GenreModifyResponse();
            var existedGenre = GetAllGenres().SingleOrDefault(t => t.Name == request.Name);
            if (request.Name != "")
            {
                if (existedGenre != null)
                {
                    genreModifyResponse.Error.ExistedError = "Genre is existed";
                    return genreModifyResponse;
                }
                var newGenre = new Genre()
                {
                    Name = request.Name
                };
                _context.Add(newGenre);
                _context.SaveChanges();
                genreModifyResponse.isModified = true;
                return genreModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    genreModifyResponse.Error.NameError = "Name is required";
                }
                return genreModifyResponse;
            }
        }

        public GenreModifyResponse UpdateGenre(int id, GenreRequest request)
        {
            var genreModifyResponse = new GenreModifyResponse();
            var existedGenre = _context.Find<Genre>(id);
            if (request.Name != "")
            {
                if (existedGenre == null)
                {
                    genreModifyResponse.Error.ExistedError = "Genre is not existed";
                    return genreModifyResponse;
                }
                existedGenre.Name = request.Name;
                _context.Update(existedGenre);
                _context.SaveChanges();
                genreModifyResponse.isModified = true;
                return genreModifyResponse;
            }
            else
            {
                if (request.Name == "")
                {
                    genreModifyResponse.Error.NameError = "Name is required";
                }
                return genreModifyResponse;
            }
        }

        public GenreModifyResponse DeleteGenre(int id)
        {
            var genreModifyResponse = new GenreModifyResponse();
            var existedGenre = _context.Find<Genre>(id);
            if (existedGenre == null)
            {
                genreModifyResponse.Error.ExistedError = "Genre is not existed";
                return genreModifyResponse;
            }
            _context.Remove<Genre>(existedGenre);
            _context.SaveChanges();
            genreModifyResponse.isModified = true;
            return genreModifyResponse;
        }
    }
}

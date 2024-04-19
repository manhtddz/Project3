using Azure.Core;
using System.Linq;
using E_Project_3_API.DTO.Error;
using E_Project_3_API.DTO.Request;
using E_Project_3_API.DTO.Response;
using E_Project_3_API.Models;
using E_Project_3_API.Services.Interfaces;
using Azure;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace E_Project_3_API.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly DataContext _dataContext;

        public MovieServices(DataContext context)
        {
            _dataContext = context;
        }

        public IEnumerable<MovieResponse> GetAllMovies()
        {
            return _dataContext.Movies.Select(movie => new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                ShopName = movie.Shop.Name,
                ShopId = movie.Shop.Id,
                Genre = movie.Genre.Name,
                GenreId = movie.Genre.Id,
                Image = movie.Image,
                Price = movie.Price,
                Description = movie.Description,
                Active = movie.Active
            }).ToList();
        }

        public MovieResponse GetMovieById(int id)
        {
            var movie = _dataContext.Find<Movie>(id);
            if (movie == null)
                return null;

            return new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                ShopName = movie.Shop.Name,
                ShopId = movie.Shop.Id,
                Genre = movie.Genre.Name,
                GenreId = movie.Genre.Id,
                Image = movie.Image,
                Price = movie.Price,
                Description = movie.Description,
                Active = movie.Active
            };
        }


        public MovieModifyResponse CreateMovie(MovieRequest movieRequest)
        {
            var movieModifyResponse = new MovieModifyResponse();
            var existedGenre = _dataContext.Find<Genre>(movieRequest.GenreId);
            var existedShop = _dataContext.Find<Shop>(movieRequest.ShopId);
            var existedMovie = _dataContext.Set<Movie>().SingleOrDefault(m => m.Name == movieRequest.Name);

            if (existedGenre != null && existedShop != null && movieRequest.Name != "" && movieRequest.Image != "" && movieRequest.Price != 0)
            {
                if (existedMovie != null)
                {
                    movieModifyResponse.Error.ExistedError = "Movie is existed";
                    return movieModifyResponse;
                }
                var newMovie = new Movie()
                {
                    Name = movieRequest.Name,
                    Image = movieRequest.Image,
                    Description = movieRequest.Description,
                    Price = movieRequest.Price,
                    Genre = existedGenre,
                    Shop = existedShop
                };
                _dataContext.Add(newMovie);
                _dataContext.SaveChanges();
                movieModifyResponse.isModified = true;
                return movieModifyResponse;
            }
            else
            {
                if (movieRequest.Name == "")
                {
                    movieModifyResponse.Error.NameError = "Name is required";
                }
                if (movieRequest.Image == "")
                {
                    movieModifyResponse.Error.ImageError = "ImageUrl is required";
                }
                if (movieRequest.Price == 0)
                {
                    movieModifyResponse.Error.PriceError = "Price is required";
                }
                if (existedGenre == null)
                {
                    movieModifyResponse.Error.GenreError = "Genre is required";
                }
                if (existedShop == null)
                {
                    movieModifyResponse.Error.ShopError = "Shop is not existed";
                }
                return movieModifyResponse;
            }
        }

        public MovieModifyResponse UpdateMovie(int id, MovieRequest movieRequest)
        {
            var response = new MovieModifyResponse();


            var existedMovie = _dataContext.Find<Movie>(id);
            var existedShop = _dataContext.Find<Shop>(movieRequest.ShopId);
            var existedGenre = _dataContext.Find<Genre>(movieRequest.GenreId);
            if (movieRequest.Name != "" && movieRequest.Image != "" && existedGenre != null && existedShop != null && movieRequest.Price != 0)
            {
                if (existedMovie == null)
                {
                    response.Error.ExistedError = "Movie not found.";
                    return response;
                }
                existedMovie.Name = movieRequest.Name;
                existedMovie.Image = movieRequest.Image;
                existedMovie.Description = movieRequest.Description;
                existedMovie.Price = movieRequest.Price;
                existedMovie.Shop = existedShop;
                existedMovie.Genre = existedGenre;

                _dataContext.Update<Movie>(existedMovie);
                _dataContext.SaveChanges();

                response.isModified = true;
                return response;
            }
            else
            {
                if (movieRequest.Name == "")
                {
                    response.Error.NameError = "Name is required";
                }
                if (movieRequest.Image == "")
                {
                    response.Error.ImageError = "ImageUrl is required";
                }
                if (movieRequest.Price == 0)
                {
                    response.Error.PriceError = "Price is required";
                }
                if (existedShop == null)
                {
                    response.Error.ShopError = "Shop is not existed";
                }
                if (existedGenre == null)
                {
                    response.Error.GenreError = "Genre is not existed";
                }
                return response;
            }
        }

        public MovieModifyResponse DeleteMovie(int id)
        {
            var response = new MovieModifyResponse();
            var movieToDelete = _dataContext.Find<Movie>(id);
            if (movieToDelete == null)
            {
                response.Error.ExistedError = "Movie not found";
                return response;
            }
            _dataContext.Remove<Movie>(movieToDelete);
            _dataContext.SaveChanges();
            response.isModified = true;
            return response;
        }

        public List<MovieResponse> GetPagingMovies(int startIndex, int limit)
        {
            var movies = _dataContext.Set<Movie>().ToList();

            var responses = new List<MovieResponse>();
            for (int i = startIndex; i < limit + startIndex; i++)
            {
                if (i >= movies.Count)
                {
                    break;
                }
                responses.Add(new MovieResponse
                {
                    Id = movies[i].Id,
                    Name = movies[i].Name,
                    ShopName = movies[i].Shop.Name,
                    ShopId = movies[i].Shop.Id,
                    Genre = movies[i].Genre.Name,
                    GenreId = movies[i].Genre.Id,
                    Image = movies[i].Image,
                    Price = movies[i].Price,
                    Description = movies[i].Description,
                    Active = movies[i].Active
                });
            }
            return responses;
        }

    }
}

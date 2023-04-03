using CaRental.Server.Data;
using CaRental.Server.Services.CategoryService;
using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace CaRental.Server.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly ICategoryService _categoryService;
        private readonly DataContext _context;

        public CarService(ICategoryService categoryService, DataContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<ServiceResponse<Car>> GetCarAsync(int id)
        {
            var response = new ServiceResponse<Car>();
            var car = await _context.Cars
                .Include(c => c.Variants)
                .ThenInclude(v => v.Edition)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this car does not exist.";
            }
            else
            {
                response.Data = car;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Car>>> GetCarsAsync()
        {
            var response = new ServiceResponse<List<Car>>()
            {
                Data = await _context.Cars.Include(c => c.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Car>>> GetCarsByCategory(string CategoryUrl)
        {
            var response = new ServiceResponse<List<Car>>
            {
                Data = await _context.Cars
                    .Where(c => c.Category.Url.ToLower().Equals(CategoryUrl.ToLower()))
                    .Include(c => c.Variants)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetCarSearchSuggestions(string searchText)
        {
            var cars =  await FindCarsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var car in cars)
            {
                if(car.Brand.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(car.Brand);
                }

                if (car.Description != null)
                {
                    var punctuation = car.Description.Where(char.IsPunctuation)
                            .Distinct().ToArray();
                    var words = car.Description.Split()
                            .Select(s => s.Trim(punctuation));
                    
                    foreach ( var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<CarSearchResultDTO>> SearchCars(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindCarsBySearchText(searchText)).Count / pageResults);
            var cars = await _context.Cars
                                .Where(c => c.Brand.ToLower().Contains(searchText.ToLower())
                                ||
                                c.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(c => c.Variants)
                                .Skip((page -1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<CarSearchResultDTO>
            {
                Data = new CarSearchResultDTO
                {
                    Cars = cars,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        private async Task<List<Car>> FindCarsBySearchText(string searchText)
        {
            return await _context.Cars
                                .Where(c => c.Brand.ToLower().Contains(searchText.ToLower())
                                ||
                                c.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(c => c.Variants)
                                .ToListAsync();
        }

        public async Task<ServiceResponse<List<Car>>> GetFeaturedCars()
        {
            var response = new ServiceResponse<List<Car>>
            {
                Data = await _context.Cars
                    .Where(c => c.Featured)
                    .Include(c => c.Variants)
                    .ToListAsync()
            };

            return response;
        }
    }
}

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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarService(ICategoryService categoryService, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _categoryService = categoryService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Car>> GetCarAsync(int id)
        {
            var response = new ServiceResponse<Car>();
            Car car = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                car = await _context.Cars
                    .Include(c => c.Variants.Where(v => !v.Deleted))
                    .ThenInclude(v => v.Edition)
                    .FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
            }
            else
            {
                car = await _context.Cars
                    .Include(c => c.Variants.Where(v => v.Visible && !v.Deleted))
                    .ThenInclude(v => v.Edition)
                    .FirstOrDefaultAsync(c => c.Id == id && !c.Deleted && c.Visible);
            }
            
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
                Data = await _context.Cars
                .Where(c => c.Visible && !c.Deleted)
                .Include(c => c.Variants.Where(v => v.Visible && !v.Deleted))
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Car>>> GetCarsByCategory(string CategoryUrl)
        {
            var response = new ServiceResponse<List<Car>>
            {
                Data = await _context.Cars
                    .Where(c => c.Category.Url.ToLower().Equals(CategoryUrl.ToLower()) && 
                        c.Visible && !c.Deleted)
                    .Include(c => c.Variants.Where(v => v.Visible && !v.Deleted))
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
                                .Where(c => c.Brand.ToLower().Contains(searchText.ToLower()) || 
                                    c.Description.ToLower().Contains(searchText.ToLower()) && 
                                    c.Visible && !c.Deleted)
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
                                .Where(c => c.Brand.ToLower().Contains(searchText.ToLower()) ||
                                    c.Description.ToLower().Contains(searchText.ToLower()) && 
                                    c.Visible && !c.Deleted)
                                .Include(c => c.Variants)
                                .ToListAsync();
        }

        public async Task<ServiceResponse<List<Car>>> GetFeaturedCars()
        {
            var response = new ServiceResponse<List<Car>>
            {
                Data = await _context.Cars
                    .Where(c => c.Featured && c.Visible && !c.Deleted)
                    .Include(c => c.Variants.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Car>>> GetAdminCars()
        {
            var response = new ServiceResponse<List<Car>>
            {
                Data = await _context.Cars
                .Where(c => !c.Deleted)
                .Include(c => c.Variants.Where(v => !v.Deleted))
                .ThenInclude(v => v.Edition)
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Car>> CreateCar(Car car)
        {
            foreach ( var variant in car.Variants)
            {
                variant.Edition = null;
            }
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Car> { Data = car };
        }

        public async Task<ServiceResponse<Car>> UpdateCar(Car car)
        {
            var dbCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id);
            if (dbCar == null)
            {
                return new ServiceResponse<Car>
                {
                    Success = false,
                    Message = "Car not found."
                };
            }
            dbCar.Brand = car.Brand;
            dbCar.Description = car.Description;
            dbCar.Image = car.Image;
            dbCar.CategoryId = car.CategoryId;
            dbCar.Visible = car.Visible;
            dbCar.Featured = car.Featured;

            foreach (var variant in car.Variants)
            {
                var dbVariant = await _context.CarVariants
                    .SingleOrDefaultAsync(v => v.CarId == variant.CarId &&
                        v.EditionId == variant.EditionId);
                if (dbVariant == null)
                {
                    variant.Edition = null;
                    variant.CarId = car.Id;
                    _context.CarVariants.Add(variant);
                }
                else
                {
                    dbVariant.EditionId = variant.EditionId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OrginalPrice = variant.OrginalPrice;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.Deleted = variant.Deleted;
                }
            }
            await _context.SaveChangesAsync();
            return new ServiceResponse<Car> { Data = car };
        }

        public async Task<ServiceResponse<bool>> DeleteCar(int id)
        {
            var dbCar = await _context.Cars.FindAsync(id);
            if(dbCar == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Car not found."
                };
            }

            dbCar.Deleted = true;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}

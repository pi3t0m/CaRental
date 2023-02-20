using CaRental.Server.Services.CategoryService;
using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Server.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly ICategoryService _categoryService;

        public CarService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return Cars;
        }

        public async Task<Car> GetCar(int id)
        {
            Car car = Cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        public async Task<List<Car>> GetCarsByCategory(string categoryUrl)
        {
            Category category = await _categoryService.GetCategoryByUrl(categoryUrl);
            return Cars.Where(a => a.CategoryId == category.Id).ToList();
        }

        public List<Car> Cars { get; set; } = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    CategoryId = 1,
                    Brand = "Maybach",
                    Description = "W223",
                    Image = "https://www.premiumfelgi.pl/userdata/gfx/57200.jpg",
                    Price = 900,
                    OrginalPrice = 1000,
                },
                new Car
                {
                    Id = 2,
                    CategoryId = 2,
                    Brand = "Mercedes",
                    Description = "AMG GT 63 S E 4-door",
                    Image = "https://motofilm.pl/wp-content/uploads/2022/02/Mercedes-AMG-GT-63-S-E-Performance-4-Drzwiowe-Coupe-1.jpg",
                    Price = 700,
                    OrginalPrice = 800,
                },
                new Car
                {
                    Id = 3,
                    CategoryId = 3,
                    Brand = "Mercedes",
                    Description = "SL500",
                    Image = "https://images8.alphacoders.com/114/1142237.jpg",
                    Price = 1000,
                    OrginalPrice = 1100,
                },
            };
    }
}

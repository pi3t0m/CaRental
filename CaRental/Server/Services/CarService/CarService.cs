﻿using CaRental.Server.Data;
using CaRental.Server.Services.CategoryService;
using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCar(int id)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return car;
        }

        public async Task<List<Car>> GetCarsByCategory(string categoryUrl)
        {
            Category category = await _categoryService.GetCategoryByUrl(categoryUrl);
            return await _context.Cars.Where(a => a.CategoryId == category.Id).ToListAsync();
        }
    }
}

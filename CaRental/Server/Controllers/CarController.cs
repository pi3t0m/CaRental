using CaRental.Client.Pages;
using CaRental.Server.Services.CarService;
using CaRental.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("Admin"), Authorize(Roles ="Admin")]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetAdminCars()
        {
            var result = await _carService.GetAdminCars();
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Car>>> CreateCar(Car car)
        {
            var result = await _carService.CreateCar(car);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Car>>>UpdateCar(Car car)
        {
            var result = await _carService.UpdateCar(car);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteCar(int id)
        {
            var result = await _carService.DeleteCar(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCars() 
        {
            var result = await _carService.GetCarsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Car>>> GetCar(int id)
        {
            var result = await _carService.GetCarAsync(id);
            return Ok(result);
        }

        [HttpGet("Category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCarsByCategory(string categoryUrl)
        {
            var result = await _carService.GetCarsByCategory(categoryUrl);
            return Ok(result);
        }

        [HttpGet("Search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<CarSearchResultDTO>>> SearchCars(string searchText, int page = 1)
        {
            var result = await _carService.SearchCars(searchText, page);
            return Ok(result);
        }

        [HttpGet("SearchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCarSearchSuggestions(string searchText)
        {
            var result = await _carService.GetCarSearchSuggestions(searchText);
            return Ok(result);
        }

        [HttpGet("Featured")]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetFeaturedCars()
        {
            var result = await _carService.GetFeaturedCars();
            return Ok(result);
        }
    }
}

using CaRental.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaRental.Client.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly HttpClient _http;

        public event Action CarsChanged;

        public List<Car> Cars { get; set; } = new List<Car>();
        public string Message { get; set; } = "Loading cars...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public List<Car> AdminCars { get ; set; }

        public CarService(HttpClient http) 
        {
            _http = http;
        }
        public async Task<ServiceResponse<Car>> GetCar(int id)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<Car>>($"api/Car/{id}");
            return result;
        }
        public async Task GetCars(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Car>>>("api/Car/Featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Car>>>($"api/Car/Category/{categoryUrl}");
            if (result != null && result.Data != null)
                Cars = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Cars.Count == 0)
                Message = "No cars found";

            CarsChanged.Invoke();
        }

        
        public async Task<List<string>> GetCarSearchSuggestions(string searchText)
        {
            var result = await _http.
                GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Car/SearchSuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchCars(string searchText, int page)
        {
            LastSearchText = searchText;

            var result = await _http
                .GetFromJsonAsync<ServiceResponse<CarSearchResultDTO>>($"api/Car/Search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Cars = result.Data.Cars;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
                
            if (Cars.Count == 0) Message = "No cars found.";
            CarsChanged?.Invoke();
        }

        public async Task GetAdminCars()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Car>>>("api/Car/admin");
            AdminCars = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminCars.Count == 0)
                Message = "no cars found.";
        }

        public async Task<Car> CreateCar(Car car)
        {
            var result = await _http.PostAsJsonAsync("api/Car", car);
            var newCar = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Car>>()).Data;
            return newCar;
        }

        public async Task<Car> UpdateCar(Car car)
        {
            Console.WriteLine("przed result");
            var result = await _http.PutAsJsonAsync($"api/Car", car);
            var content =  await result.Content.ReadFromJsonAsync<ServiceResponse<Car>>();
            Console.WriteLine("po result");
            return content.Data;
        }

        public async Task DeleteCar(Car car)
        {
            var result = await _http.DeleteAsync($"api/Car/{car.Id}");
        }
    }
}

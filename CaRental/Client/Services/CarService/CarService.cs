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

        public event Action onChange;

        public List<Car> Cars { get; set; } = new List<Car>();

        public CarService(HttpClient http) 
        {
            _http = http;
        }
        public async Task LoadCars(string categoryUrl = null)
        {
            if(categoryUrl == null)
            {
                Cars = await _http.GetFromJsonAsync<List<Car>>($"api/Car/");
            }
            else
            {
                Cars = await _http.GetFromJsonAsync<List<Car>>($"api/Car/Category/{categoryUrl}");
            }
            onChange.Invoke();

        }

        public async Task<Car> GetCar(int id)
        {
            return await _http.GetFromJsonAsync<Car>($"api/Car/{id}");
        }

        public async Task<List<Car>> SearchCars(string searchText)
        {
            return await _http.GetFromJsonAsync<List<Car>>($"api/Car/Search/{searchText}");
        }
    }
}

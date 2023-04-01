using CaRental.Shared;

namespace CaRental.Client.Services.CarService
{
    public interface ICarService
    {
        event Action CarsChanged;
        List<Car> Cars { get; set; }
        string Message { get; set; }
        Task GetCars(string? categoryUrl = null);
        Task<ServiceResponse<Car>> GetCar(int id);
        Task SearchCars(string searchText);
        Task<List<string>> GetCarSearchSuggestions(string searchText);
    }
}

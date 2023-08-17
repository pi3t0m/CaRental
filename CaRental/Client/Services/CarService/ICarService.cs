using CaRental.Shared;

namespace CaRental.Client.Services.CarService
{
    public interface ICarService
    {
        event Action CarsChanged;
        List<Car> Cars { get; set; }
        List<Car> AdminCars { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetCars(string? categoryUrl = null);
        Task<ServiceResponse<Car>> GetCar(int id);
        Task SearchCars(string searchText, int page);
        Task<List<string>> GetCarSearchSuggestions(string searchText);
        Task GetAdminCars();
        Task <Car> CreateCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task DeleteCar(Car car);

    }
}

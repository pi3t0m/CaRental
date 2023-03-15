using CaRental.Shared;

namespace CaRental.Server.Services.CarService
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();
        Task<List<Car>> GetCarsByCategory(string CategoryUrl);
        Task<Car> GetCar(int id);
        Task<List<Car>> SearchCars(string searchText);
    }
}

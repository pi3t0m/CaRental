using CaRental.Shared;

namespace CaRental.Client.Services.CarService
{
    interface ICarService
    {
        event Action onChange;
        List<Car> Cars { get; set; }

        Task LoadCars(string categoryUrl = null);
        Task<Car> GetCar(int id);
    }
}

using CaRental.Shared;

namespace CaRental.Client.Services.CarService
{
    interface ICarService
    {
        List<Car> Cars { get; set; }

        void LoadCars();

    }
}

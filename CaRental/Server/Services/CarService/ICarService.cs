namespace CaRental.Server.Services.CarService
{
    public interface ICarService
    {
        Task<ServiceResponse<List<Car>>> GetCarsAsync();
        Task<ServiceResponse<Car>> GetCarAsync(int id);
        Task<ServiceResponse<List<Car>>> GetCarsByCategory(string CategoryUrl);
        Task<ServiceResponse<CarSearchResultDTO>> SearchCars(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetCarSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Car>>> GetFeaturedCars();
        Task<ServiceResponse<List<Car>>> GetAdminCars();
        Task<ServiceResponse<Car>> CreateCar(Car car);
        Task<ServiceResponse<Car>> UpdateCar(Car car);
        Task<ServiceResponse<bool>> DeleteCar(int id);
    }
}

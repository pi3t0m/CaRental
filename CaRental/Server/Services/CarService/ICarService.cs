namespace CaRental.Server.Services.CarService
{
    public interface ICarService
    {
        Task<ServiceResponse<List<Car>>> GetCarsAsync();
        Task<ServiceResponse<Car>> GetCarAsync(int id);
        Task<ServiceResponse<List<Car>>> GetCarsByCategory(string CategoryUrl);
        Task<ServiceResponse<List<Car>>> SearchCars(string searchText);
        Task<ServiceResponse<List<string>>> GetCarSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Car>>> GetFeaturedCars();
    }
}

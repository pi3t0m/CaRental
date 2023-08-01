namespace CaRental.Server.Services.EditionService
{
    public interface IEditionService
    {
        Task<ServiceResponse<List<Edition>>> GetEditions();
        Task<ServiceResponse<List<Edition>>> AddEdition(Edition edition);
        Task<ServiceResponse<List<Edition>>> UpdateEdition(Edition edition);

    }
}

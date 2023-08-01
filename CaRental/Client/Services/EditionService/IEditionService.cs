namespace CaRental.Client.Services.EditionService
{
    public interface IEditionService
    {
        event Action OnChange;
        public List<Edition> Editions { get; set; }
        Task GetEditions();
        Task AddEdition(Edition edition);
        Task UpdateEdition(Edition edition);
        Edition CreateNewEdition();
    }
}

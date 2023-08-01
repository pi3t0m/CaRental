namespace CaRental.Client.Services.EditionService
{
    public class EditionService : IEditionService
    {
        private readonly HttpClient _http;

        public EditionService(HttpClient http)
        {
            _http = http;
        }
        public List<Edition> Editions { get; set; } = new List<Edition>();

        public event Action OnChange;

        public async Task AddEdition(Edition edition)
        {
            var response = await _http.PostAsJsonAsync("api/edition", edition);
            Editions = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Edition>>>()).Data;
            OnChange.Invoke();
        }

        public Edition CreateNewEdition()
        {
            var newEdition = new Edition { IsNew = true, Editing = true };

            Editions.Add(newEdition);
            OnChange.Invoke();
            return newEdition;
        }

        public async Task GetEditions()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Edition>>>("api/edition");
            Editions = result.Data;
        }

        public async Task UpdateEdition(Edition edition)
        {
            var response = await _http.PutAsJsonAsync("api/edition", edition);
            Editions = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Edition>>>()).Data;
            OnChange.Invoke();
        }
    }
}

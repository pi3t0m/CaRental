using Microsoft.EntityFrameworkCore;

namespace CaRental.Server.Services.EditionService
{
    public class EditionService : IEditionService
    {
        private readonly DataContext _context;

        public EditionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Edition>>> AddEdition(Edition edition)
        {
            edition.Editing = edition.IsNew = false;
            _context.Editions.Add(edition);
            await _context.SaveChangesAsync();

            return await GetEditions();
        }

        public async Task<ServiceResponse<List<Edition>>> GetEditions()
        {
            var editions = await _context.Editions.ToListAsync();
            return new ServiceResponse<List<Edition>> { Data = editions };
        }

        public async Task<ServiceResponse<List<Edition>>> UpdateEdition(Edition edition)
        {
            var dbEdition = await _context.Editions.FindAsync(edition.Id);
            if (dbEdition == null)
            {
                return new ServiceResponse<List<Edition>>
                {
                    Success = false,
                    Message = "Car edition not found."
                };
            }

            dbEdition.Name = edition.Name;
            await _context.SaveChangesAsync();

            return await GetEditions();
        }
    }
}

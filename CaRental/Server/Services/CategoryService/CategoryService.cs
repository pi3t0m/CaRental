using CaRental.Shared;
using System.Threading.Tasks;
using System.Linq;
using CaRental.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CaRental.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}

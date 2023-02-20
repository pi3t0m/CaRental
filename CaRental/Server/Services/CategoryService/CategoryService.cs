using CaRental.Shared;
using System.Threading.Tasks;
using System.Linq;

namespace CaRental.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>
            {
                new Category { Id = 1, Name = "Exclusives", Url = "exclusive", Icon = "plus" },
                new Category { Id = 2, Name = "Sports", Url = "sport", Icon = "plus" },
                new Category { Id = 3, Name = "Oldschool", Url = "oldschool", Icon = "plus" }
            };
        public async Task<List<Category>> GetCategories()
        {
            return Categories;
        }

        public async Task<Category> GetCategoryByUrl(string categoryUrl)
        {
            return Categories.FirstOrDefault(c => c.Url.ToLower().Equals(categoryUrl.ToLower()));
        }
    }
}

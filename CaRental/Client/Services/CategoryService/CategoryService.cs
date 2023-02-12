using CaRental.Shared;

namespace CaRental.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>();

        public void LoadCategories()
        {
            Categories = new List<Category> 
            { 
                new Category { Id = 1, Name = "Exclusives", Url = "exclusive", Icon = "plus" },
                new Category { Id = 2, Name = "Sports", Url = "sport", Icon = "plus" },
                new Category { Id = 3, Name = "Oldschool", Url = "oldschool", Icon = "plus" }
            };
        }
    }
}

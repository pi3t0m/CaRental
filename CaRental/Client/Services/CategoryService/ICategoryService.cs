using CaRental.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaRental.Client.Services.CategoryService
{
    interface ICategoryService
    {
        event Action OnChange;
        List<Category> Categories { get; set;  }
        List<Category> AdminCategories { get; set; }
        Task GetCategories();
        Task GetAdminCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Category CreateNewCategory();
    }
}

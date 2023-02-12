using CaRental.Shared;

namespace CaRental.Client.Services.CategoryService
{
    interface ICategoryService
    {
        List<Category> Categories { get; set;  }
        void LoadCategories();
    }
}

using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();

        Task<Category> GetCategoryByUrl(string categoryUrl);
    }
}

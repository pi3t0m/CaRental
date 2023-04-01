using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories();
    }
}

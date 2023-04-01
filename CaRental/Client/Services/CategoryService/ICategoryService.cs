using CaRental.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaRental.Client.Services.CategoryService
{
    interface ICategoryService
    {
        List<Category> Categories { get; set;  }
        Task GetCategories();
    }
}

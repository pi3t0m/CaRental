using CaRental.Client.Services.CarService;
using CaRental.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CaRental.Client.Services.CategoryService;
using Blazored.LocalStorage;
using Blazored.Toast;
using CaRental.Client.Services.CartService;
using Microsoft.AspNetCore.Components.Authorization;

namespace CaRental.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }

}

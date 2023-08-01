global using CaRental.Shared;
global using System.Net.Http.Json;
global using CaRental.Client.Services.CarService;
global using CaRental.Client.Services.CategoryService;
global using CaRental.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using CaRental.Client.Services.OrderService;
global using CaRental.Client.Services.EditionService;
using CaRental.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazored.Toast;
using CaRental.Client.Services.CartService;
using CaRental.Client.Services.StatsService;

namespace CaRental.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IAuthService , AuthService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddBlazoredToast();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<IStatsService, StatsService>();
            builder.Services.AddScoped<IEditionService, EditionService>();

            await builder.Build().RunAsync();
        }
    }

}

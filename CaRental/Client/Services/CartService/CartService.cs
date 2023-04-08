using Blazored.LocalStorage;
using Blazored.Toast.Services;
using CaRental.Client.Pages;
using CaRental.Client.Services.CarService;
using CaRental.Shared;
using System.Net.Http.Json;

namespace CaRental.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public CartService(ILocalStorageService localStorage, HttpClient http,
            IAuthService authService) 
        {
            _localStorage = localStorage;
            _http = http;
            _authService = authService;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.PostAsJsonAsync("api/cart/add", cartItem);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }
                cart.Add(cartItem);

                await _localStorage.SetItemAsync("cart", cart);
            }
            await GetCartItemsCount();

        }

        public async Task<List<CartCarResponseDTO>> GetCartCars()
        {
            if(await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<CartCarResponseDTO>>>("api/cart");
                return response.Data;
            }
            else
            {
                var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cartItems == null)
                    return new List<CartCarResponseDTO>();
                var response = await _http.PostAsJsonAsync("api/cart/cars", cartItems);
                var cartCars =
                    await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartCarResponseDTO>>>();
                return cartCars.Data;
            }
        }

        public async Task RemoveCarFromCart(int carId, int editionId)
        {
            if(await _authService.IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/cart/{carId}/{editionId}");
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }

                var cartItem = cart.Find(x => x.CarId == carId
                    && x.EditionId == editionId);
                if (cartItem != null)
                {
                    cart.Remove(cartItem);
                    await _localStorage.SetItemAsync("cart", cart);
                    await GetCartItemsCount();
                }
            }
        }

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (localCart == null)
            {
                return;
            }

            await _http.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _localStorage.RemoveItemAsync("cart");
            }
        }

        public async Task GetCartItemsCount()
        {
            if(await _authService.IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await _localStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }

            OnChange.Invoke();
        }
        
        public async Task<bool> CheckCars(int carId)
        {
            List<CartCarResponseDTO> carlist = await GetCartCars();
            var checkCars = carlist.Find(ci => ci.CarId == carId) != null;
            Console.WriteLine(checkCars);
            return checkCars;
        }
        
    }
}

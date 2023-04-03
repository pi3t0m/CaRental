using Blazored.LocalStorage;
using Blazored.Toast.Services;
using CaRental.Client.Services.CarService;
using CaRental.Shared;
using System.Net.Http.Json;

namespace CaRental.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CartService(ILocalStorageService localStorage, HttpClient http) 
        {
            _localStorage = localStorage;
            _http = http;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            cart.Add(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();

        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }

        public async Task<List<CartCarResponseDTO>> GetCartCars()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            var response = await _http.PostAsJsonAsync("api/cart/cars", cartItems);
            var cartCars =
                await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartCarResponseDTO>>>();
            return cartCars.Data;
        }

        public async Task RemoveCarFromCart(int carId, int editionId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.CarId == carId
                && x.EditionId == editionId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }
    }
}

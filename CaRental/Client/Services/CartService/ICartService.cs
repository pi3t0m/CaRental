using CaRental.Shared;

namespace CaRental.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CarVariant carVariant);
        Task<List<CartItem>> GetCartItems();
        Task DeleteItem(CartItem item);
    }
}

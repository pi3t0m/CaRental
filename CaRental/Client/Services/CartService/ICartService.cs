using CaRental.Shared;

namespace CaRental.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartCarResponseDTO>> GetCartCars();
        Task RemoveCarFromCart(int carId, int editionId);
        Task StoreCartItems(bool emptyLocalCart);
        Task GetCartItemsCount();
        Task<bool> CheckCars(int carId);
    }
}

namespace CaRental.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartCarResponseDTO>>> GetCartCars(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartCarResponseDTO>>> StoreCartItems(List<CartItem> cartItems);
        Task<ServiceResponse<int>> GetCartItemsCount();
        Task<ServiceResponse<List<CartCarResponseDTO>>> GetDbCartCars();
        Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
        Task<ServiceResponse<bool>> RemoveItemFromCart(int carId, int editionId);
    }
}

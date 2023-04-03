namespace CaRental.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartCarResponseDTO>>> GetCartCars(List<CartItem> cartItems);
    }
}

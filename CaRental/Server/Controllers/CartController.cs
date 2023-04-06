using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CaRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("cars")]
        public async Task<ActionResult<ServiceResponse<List<CartCarResponseDTO>>>> GetCartCars(List<CartItem> cartItems)
        {
            var result = await _cartService.GetCartCars(cartItems);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartCarResponseDTO>>>> StoreCartItems(List<CartItem> cartItems)
        {
            var result = await _cartService.StoreCartItems(cartItems);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
        {
            var result = await _cartService.AddToCart(cartItem);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
        {
            return await _cartService.GetCartItemsCount();
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<CartCarResponseDTO>>> GetDbCartCars()
        {
            var result = await _cartService.GetDbCartCars();
            return Ok(result);
        }

        [HttpDelete("{carId}/{editionId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> ReomveItemFromCart(int carId, int editionId)
        {
            var result = await _cartService.RemoveItemFromCart(carId, editionId);
            return Ok(result);
        }
    }
}

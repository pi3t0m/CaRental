using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

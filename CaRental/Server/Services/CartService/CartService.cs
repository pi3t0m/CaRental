using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CaRental.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public CartService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CartCarResponseDTO>>> GetCartCars(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartCarResponseDTO>>
            {
                Data = new List<CartCarResponseDTO>()
            };

            foreach (var item in cartItems)
            {
                var car = await _context.Cars
                    .Where(c => c.Id == item.CarId)
                    .FirstOrDefaultAsync();

                if ( car == null )
                {
                    continue;
                }

                var carVarinat = await _context.CarVariants
                    .Where( v => v.CarId == item.CarId
                    && v.EditionId == item.EditionId)
                    .Include(v => v.Edition)
                    .FirstOrDefaultAsync();

                if(carVarinat == null) 
                {
                    continue;
                }

                var cartCar = new CartCarResponseDTO
                {
                    CarId = car.Id,
                    Brand = car.Brand,
                    Image = car.Image,
                    Price = carVarinat.Price,
                    Edition = carVarinat.Edition.Name,
                    EditionId = carVarinat.EditionId
                    
                };                
                result.Data.Add(cartCar);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CartCarResponseDTO>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetDbCartCars();
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        { 
            var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count;
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CartCarResponseDTO>>> GetDbCartCars(int? userId = null)
        {
            if (userId == null)
                userId = _authService.GetUserId();

            return await GetCartCars(await _context.CartItems
                .Where(ci => ci.UserId == userId).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CarId == cartItem.CarId &&
                ci.EditionId == cartItem.EditionId && ci.UserId == cartItem.UserId);
            if (sameItem == null) 
            {
                _context.CartItems.Add(cartItem);
            }
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int carId, int editionId)
        {
            var dbCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CarId == carId &&
                ci.EditionId == editionId && ci.UserId == _authService.GetUserId());
            
            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }
            
            _context.CartItems.Remove(dbCartItem);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}

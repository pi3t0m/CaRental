using Microsoft.EntityFrameworkCore;

namespace CaRental.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;

        public CartService(DataContext context)
        {
            _context = context;
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
    }
}

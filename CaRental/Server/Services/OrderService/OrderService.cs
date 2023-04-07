using Microsoft.EntityFrameworkCore;

namespace CaRental.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context,
            ICartService cartService,
            IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponseDTO>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponseDTO>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Car)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponseDTO>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponseDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Car = o.OrderItems.Count > 1 ?
                    $"{o.OrderItems.First().Car.Brand} and" +
                    $" {o.OrderItems.Count -1} more..." :
                    o.OrderItems.First().Car.Brand,
                CarImage = o.OrderItems.First().Car.Image
            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var cars = (await _cartService.GetDbCartCars()).Data;
            decimal totalPrice = 0;
            cars.ForEach(cars => totalPrice += cars.Price);

            var orderItems = new List<OrderItem>();
            cars.ForEach(car => orderItems.Add(new OrderItem
            {
                CarId = car.CarId,
                EditionId = car.EditionId,
                TotalPrice = car.Price
            }));

            var order = new Order
            {
                UserId = _authService.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == _authService.GetUserId()));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}

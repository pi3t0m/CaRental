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

        public async Task<ServiceResponse<OrderDetailsResponseDTO>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponseDTO>();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Car)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Edition)
                .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponseDTO
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Cars = new List<OrderDetailsCarResponseDTO>()
            };

            order.OrderItems.ForEach(item =>
            orderDetailsResponse.Cars.Add(new OrderDetailsCarResponseDTO
            {
                CarId = item.CarId,
                Image = item.Car.Image,
                Edition = item.Edition.Name,
                Brand = item.Car.Brand,
                TotalPrice = item.TotalPrice
            }));

            response.Data = orderDetailsResponse;

            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(int userId)
        {
            var cars = (await _cartService.GetDbCartCars(userId)).Data;
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
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == userId));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}

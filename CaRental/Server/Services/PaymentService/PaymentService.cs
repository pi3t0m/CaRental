using Azure;
using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace CaRental.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        const string secret = "whsec_9652bee2ce99d25a5beec79138a97978ba74451428bd4526cba93a2fb0507a1c";

        public PaymentService(ICartService cartService,
            IAuthService authService,
            IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51Mm2kKF0PDfFtOyogmRyX85qgph73wgy3fSpGXQva87Dn6FZEC9WlLovRs9rOJIYp6gll1srcjKEZgYNoeGDvsMJ00LOf4yWAC";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            var cars = (await _cartService.GetDbCartCars()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            cars.ForEach(car => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = car.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = car.Brand,
                        Images = new List<string> { car.Image }
                    }
                },
                Quantity = 1
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7065/order-success",
                CancelUrl = "https://localhost:7065/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try 
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["stripe-Signature"],
                        secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            } 
            catch (StripeException e) 
            {
                return new ServiceResponse<bool> { Data = false, Success= false, Message= e.Message };
            }

        }
    }
}

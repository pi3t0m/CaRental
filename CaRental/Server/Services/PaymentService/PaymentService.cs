using Azure;
using CaRental.Shared;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace CaRental.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51Mm2kKF0PDfFtOyogmRyX85qgph73wgy3fSpGXQva87Dn6FZEC9WlLovRs9rOJIYp6gll1srcjKEZgYNoeGDvsMJ00LOf4yWAC";
        }

       /* public Session CreateCheckoutSession(List<CartItem> cartItems)
        {
            
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(ci => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = ci.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ci.CarTitle,
                        Images = new List<string> { ci.Image }
                    }
                },
                Quantity= ci.Quantity,
            }));

            var options = new SessionCreateOptions
            {
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "http://localhost:5117/success",
                CancelUrl = "http://localhost:5117/cart",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        } */
    }
}

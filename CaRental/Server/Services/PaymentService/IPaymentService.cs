using CaRental.Shared;
using Stripe.Checkout;

namespace CaRental.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}

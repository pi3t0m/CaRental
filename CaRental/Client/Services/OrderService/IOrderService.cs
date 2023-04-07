﻿namespace CaRental.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task PlaceOrder();
        Task<List<OrderOverviewResponseDTO>> GetOrders();
    }
}

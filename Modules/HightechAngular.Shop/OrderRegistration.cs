using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Microsoft.Extensions.DependencyInjection;
using HightechAngular.Orders.Services;

namespace HightechAngular.Shop
{
    public static class OrderRegistration
    {
        public static void RegisterOrder(this IServiceCollection services)
        {
            services.AddStateOrder<CompleteOrderContext, CompleteOrder, Order.Shipped, Order.Complete>();
            services.AddStateOrder<DisputeOrderContext, DisputeOrder, Order.Shipped, Order.Disputed>();
            services.AddStateOrder<PayMyOrderContext, PayOrder, Order.New, Order.Paid>();
        }
    }
}
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace HightechAngular.Admin
{
    public static class AdminRegistrations
    {
        public static void RegisterAdmin(this IServiceCollection services)
        {
            services.AddScoped<IDropdownProvider<PayOrder>, PayOrderDropdownProvider>();
            services.AddScoped<IDropdownProvider<OrderListItem>, OrderListItemDropdownProvider>();
            services.AddScoped<IDropdownProvider<AllOrdersItem>, CreateOrderDropdownProvider>();

            services.AddStateOrder<PayMyOrderContext, PayOrder, Order.New, Order.Paid>();
            services.AddStateOrder<ShipOrderContext, ShipOrder, Order.Paid, Order.Shipped>();
            services.AddStateOrder<CompleteOrderAdminContext, CompleteOrderAdmin, Order.Disputed, Order.Complete>();
        }
    }
}
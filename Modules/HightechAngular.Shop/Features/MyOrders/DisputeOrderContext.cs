using HightechAngular.Orders.Entities;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class DisputeOrderContext : OrderStatusContextBase<DisputeOrder>
    {
        [Required]
        public Order.Disputed State => Order.As<Order.Disputed>();
        public DisputeOrderContext(DisputeOrder request, Order order) : base(request, order)
    {
    }
}
}

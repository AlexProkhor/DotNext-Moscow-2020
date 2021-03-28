using HightechAngular.Orders.Entities;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderContext : OrderStatusContextBase<PayOrder>
    {
        [Required]
        public Order.New State => Order.As<Order.New>();
        public PayMyOrderContext(PayOrder request, Order order) : base(request, order)
        {
        }
    }
}

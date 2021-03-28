using HightechAngular.Orders.Entities;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderContext : OrderStatusContextBase<CompleteOrder>
    {
        [Required]
        public Order.Shipped State => Order.As<Order.Shipped>();
        public CompleteOrderContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}

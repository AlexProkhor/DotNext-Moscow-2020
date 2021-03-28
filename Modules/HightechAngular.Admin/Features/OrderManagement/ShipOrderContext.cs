using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderContext : OrderStatusContextBase<ShipOrder>
    {
        [Required]
        public Order.Paid State => Order.As<Order.Paid>();

        public ShipOrderContext(ShipOrder request, Order order) : base(request, order)
        {
        }
    }
}
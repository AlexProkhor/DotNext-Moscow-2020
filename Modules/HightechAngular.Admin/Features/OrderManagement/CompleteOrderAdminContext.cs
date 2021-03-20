using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminContext : OrderStatusContextBase<CompleteOrder>
    {
        [Required]
        public Order.Disputed State => Order.As<Order.Disputed>();
        public CompleteOrderAdminContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}

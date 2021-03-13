using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminContext : OrderStatusContextBase<CompleteOrder>
    {
        public CompleteOrderAdminContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}

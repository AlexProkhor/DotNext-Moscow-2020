using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderContext : OrderStatusContextBase<ShipOrder>
    {
        public ShipOrderContext(ShipOrder request, Order order) : base(request, order)
        {
        }
    }
}
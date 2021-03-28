using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderContext : ChangeStateOrderContext<ShipOrder, Order.Paid>
    {
        public ShipOrderContext(ShipOrder request, Order order) : base(request, order)
        {
        }
    }
}
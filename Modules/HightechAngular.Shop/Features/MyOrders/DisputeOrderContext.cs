using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class DisputeOrderContext : ChangeStateOrderContext<DisputeOrder, Order.Shipped>
    {
        public DisputeOrderContext(DisputeOrder request, Order order) : base(request, order)
        {
        }
    }
}

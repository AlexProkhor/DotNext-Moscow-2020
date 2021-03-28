using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderContext : ChangeStateOrderContext<CompleteOrder, Order.Shipped>
    {
        public CompleteOrderContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}

using HightechAngular.Orders.Entities;
using HightechAngular.Core.Base;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderContext : ChangeStateOrderContext<PayOrder, Order.New>
    {
        public PayMyOrderContext(PayOrder request, Order order) : base(request, order)
        {
        }
    }
}

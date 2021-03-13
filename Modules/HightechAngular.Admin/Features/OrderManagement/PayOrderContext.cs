using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderContext : BaseOrderStatusContext<PayOrder>
    {
        public PayOrderContext(PayOrder request, Order order) : base(request, order)
        {
        }
    }
}

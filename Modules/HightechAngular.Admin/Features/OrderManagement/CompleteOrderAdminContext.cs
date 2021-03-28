using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminContext : ChangeStateOrderContext<CompleteOrderAdmin, Order.Disputed>
    {
        public CompleteOrderAdminContext(CompleteOrderAdmin request, Order order) : base(request, order)
        {
        }
    }
}

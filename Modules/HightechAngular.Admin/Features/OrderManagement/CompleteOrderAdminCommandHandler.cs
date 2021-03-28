using Force.Ccc;
using HightechAngular.Orders.Entities;
using HightechAngular.Core.Base;
using HightechAngular.Shop.Features.MyOrders;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminCommandHandler : CompleteOrderCommandHandlerBase<CompleteOrderAdmin, Order.Disputed>
    {
        public CompleteOrderAdminCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Complete ChangeStateOrder(ChangeStateOrderContext<CompleteOrderAdmin, Order.Disputed> input)
        {
            return input.State.BecomeComplete();
        }
    }
}

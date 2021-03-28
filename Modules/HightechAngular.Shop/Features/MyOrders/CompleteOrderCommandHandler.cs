using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderCommandHandler : CompleteOrderCommandHandlerBase<CompleteOrder, Order.Shipped>
    {
        public CompleteOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Complete ChangeStateOrder(ChangeStateOrderContext<CompleteOrder, Order.Shipped> input)
        {
            return input.State.BecomeComplete();
        }
    }
}
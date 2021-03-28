using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class DisputeOrderCommandHandler :
        DomainHandlerBase<
            DisputeOrder,
            Order.Shipped,
            Order.Disputed>
    {
        public DisputeOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Disputed ChangeStateOrder(ChangeStateOrderContext<DisputeOrder, Order.Shipped> input)
        {
            return input.State.BecomeDisputed();
        }
    }
}
using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderCommandHandler :
         DomainHandlerBase<
             ShipOrder,
             Order.Paid,
             Order.Shipped>
    {
        public ShipOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Shipped ChangeStateOrder(ChangeStateOrderContext<ShipOrder, Order.Paid> input)
        {
            return input.State.BecomeShipped();
        }
    }
}
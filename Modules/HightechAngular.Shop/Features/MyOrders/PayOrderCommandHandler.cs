using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using HightechAngular.Shop.Features.MyOrders.Base;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderCommandHandler : PayOrderCommandHandlerBase<PayOrder>
    {
        public PayOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Paid ChangeStateOrder(ChangeStateOrderContext<PayOrder, Order.New> input)
        {
            return input.State.BecomePaid();
        }
    }
}
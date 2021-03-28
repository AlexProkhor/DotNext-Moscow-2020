using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.MyOrders.Base
{
    public abstract class PayOrderCommandHandlerBase<TCommand> :
        DomainHandlerBase<
            TCommand,
            Order.New,
            Order.Paid>
        where TCommand : ChangeOrderStateBase
    {
        protected PayOrderCommandHandlerBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

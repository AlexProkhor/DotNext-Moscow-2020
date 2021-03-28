using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.MyOrders
{
    public abstract class CompleteOrderCommandHandlerBase<TCommand, TFrom> :
       DomainHandlerBase<
           TCommand,
           TFrom,
           Order.Complete>
       where TCommand : ChangeOrderStateBase
       where TFrom : Order.OrderStateBase
    {
        protected CompleteOrderCommandHandlerBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
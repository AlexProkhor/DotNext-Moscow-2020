using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Core.Base
{
    public class ChangeStateOrderContext<TCommand, TState> :
       OrderStatusContextBase<TCommand>
       where TCommand : ChangeOrderStateBase
       where TState : Order.OrderStateBase
    {
        [Required]
        public TState State => Order.As<TState>();

        protected ChangeStateOrderContext(TCommand request, Order order) : base(request, order)
        {
        }
    }
}
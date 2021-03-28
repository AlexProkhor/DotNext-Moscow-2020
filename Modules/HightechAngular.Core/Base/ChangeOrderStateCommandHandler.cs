using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace HightechAngular.Orders.Base
{
    public class ChangeOrderStateCommandHandler<TCommand, TFrom, TTo> :
         ICommandHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<CommandResult<OrderStatus>>>
         where TCommand : ChangeOrderStateBase
         where TFrom : Order.OrderStateBase
         where TTo : Order.OrderStateBase
    {
        private IHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<CommandResult<TTo>>> Handler { get; }

        public ChangeOrderStateCommandHandler(
            IHandler<
                ChangeStateOrderContext<TCommand, TFrom>,
                Task<CommandResult<TTo>>> handler)
        {
            Handler = handler;
        }

        public Task<CommandResult<OrderStatus>> Handle(ChangeStateOrderContext<TCommand, TFrom> input)
        {
            return Handler
                .Handle(input)
                .AwaitAndPipeTo(x =>
                    x.Match(
                        result => new CommandResult<OrderStatus>(result.EligibleStatus),
                        failure => failure));
        }
    }
}

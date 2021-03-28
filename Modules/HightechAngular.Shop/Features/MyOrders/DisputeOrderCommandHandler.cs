using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class DisputeOrderCommandHandler : ICommandHandler<DisputeOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(DisputeOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.State.BecomeDisputed();

            return result.EligibleStatus;
        }
    }
}
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderCommandHandler :
        ICommandHandler<ShipOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(ShipOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Order.With((Order.Paid newOrder) => newOrder.BecomeShipped());
         
            return result.EligibleStatus;
        }
    }
}
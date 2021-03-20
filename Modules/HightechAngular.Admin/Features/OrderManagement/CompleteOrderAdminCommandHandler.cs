using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminCommnadHandler :
          ICommandHandler<CompleteOrderAdminContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrderAdminContext input)
        {
            await Task.Delay(1000);
            var result = input.Order.With((Order.Disputed newOrder) => newOrder.BecomeComplete());

            return result.EligibleStatus;
        }
    }
}

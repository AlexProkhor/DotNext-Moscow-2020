using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayOrderCommandHandler :
        ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayOrderCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Order.With((Order.New newOrder) => newOrder.BecomePaid());

            _unitOfWork.Commit();
            return result.EligibleStatus;
        }
    }

}
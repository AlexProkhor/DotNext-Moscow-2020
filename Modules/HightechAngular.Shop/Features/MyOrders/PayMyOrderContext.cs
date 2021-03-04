using Force.Cqrs;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderContext :
           ByIntIdOperationContextBase<ChangeOrderStateBase>,
           ICommand<Task<HandlerResult<OrderStatus>>>
    {
        [Required]
        public Order Order { get; }
        public PayMyOrderContext(ChangeOrderStateBase request, Order order) : base(request)
        {
            Order = order;
        }
    }
}

using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class OrderStatusContextBase<T> :
        ByIntIdOperationContextBase<T>,
        ICommand<Task<HandlerResult<OrderStatus>>>
        where T : class, IHasId<int>
    {
        [Required]
        public Order Order { get; }
        public OrderStatusContextBase(T request, Order order) : base(request)
        {
            Order = order;
        }
    }
}
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminContext :
        ByIntIdOperationContextBase<CompleteOrderAdmin>,
        ICommand<Task<HandlerResult<OrderStatus>>>

    {
        [Required]
        public Order Order { get; }

        public CompleteOrderAdminContext(CompleteOrderAdmin request, Order order) : base(request)
        {
            Order = order;
        }
    }
}

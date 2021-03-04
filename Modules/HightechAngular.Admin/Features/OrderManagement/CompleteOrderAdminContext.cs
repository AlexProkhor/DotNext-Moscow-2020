using Force.Cqrs;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminContext :
        ByIntIdOperationContextBase<ChangeOrderStateBase>,
        ICommand<Task<HandlerResult<OrderStatus>>>

    {
        [Required]
        public Order Order { get; }

        public CompleteOrderAdminContext(ChangeOrderStateBase request, Order order) : base(request)
        {
            Order = order;
        }
    }
}

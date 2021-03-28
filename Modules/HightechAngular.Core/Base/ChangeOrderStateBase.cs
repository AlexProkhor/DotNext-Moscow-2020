using System.Threading.Tasks;
using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;

namespace HightechAngular.Orders.Base
{
    public abstract class ChangeOrderStateBase :
        HasIdBase,
        ICommand<Task<HandlerResult<OrderStatus>>>
    {
        public int OrderId { get; set; }
    }
}
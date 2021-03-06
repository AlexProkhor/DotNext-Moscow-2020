using System.Threading.Tasks;
using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;

namespace HightechAngular.Core.Base
{ 
    public abstract class ChangeOrderStateBase :
        HasIdBase,
        ICommand<Task<CommandResult<OrderStatus>>>
    {
        public int OrderId { get; set; }
    }
}
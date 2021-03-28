using Force.Cqrs;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HightechAngular.Orders.Services
{
    public static class ServicesExtensions
    {
        public static void AddStateOrder<TContext, TCommand, TFrom, TTo>(this IServiceCollection services)
            where TContext : ChangeStateOrderContext<TCommand, TFrom>
            where TCommand : ChangeOrderStateBase
            where TFrom : Order.OrderStateBase
            where TTo : Order.OrderStateBase
        {
            services.AddScoped<
                ICommandHandler<TContext, Task<CommandResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<TCommand, TFrom, TTo>>();
        }
    }
}

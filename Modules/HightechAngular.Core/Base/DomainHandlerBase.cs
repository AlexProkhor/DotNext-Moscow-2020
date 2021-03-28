using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using System;
using System.Threading.Tasks;

namespace HightechAngular.Orders.Base
{
    public abstract class DomainHandlerBase<TCommand, TFrom, TTo> :
           IHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<HandlerResult<TTo>>>
           where TCommand : ChangeOrderStateBase
           where TFrom : Order.OrderStateBase
           where TTo : Order.OrderStateBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected DomainHandlerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HandlerResult<TTo>> Handle(ChangeStateOrderContext<TCommand, TFrom> input)
        {
            using var tr = _unitOfWork.BeginTransaction();
            try
            {
                await Task.Delay(300);
                var result = ChangeStateOrder(input);

                _unitOfWork.Commit();
                await tr.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                await tr.RollbackAsync();
                return FailureInfo.Invalid(e.Message);
            }
        }

        protected abstract TTo ChangeStateOrder(ChangeStateOrderContext<TCommand, TFrom> input);
    }
}

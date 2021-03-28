using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Shop.Features.Cart
{
    public class UpdateProductInCartContextBase<TIn, TOut> : ByIntIdOperationContextBase<TIn>,
        ICommand<TOut>  where TIn : class, IHasId<int>
    {
        [Required]
        public Product Product { get; }
        public UpdateProductInCartContextBase(TIn request, Product product) : base(request)
        {
            Product = product;
        }
    }
}

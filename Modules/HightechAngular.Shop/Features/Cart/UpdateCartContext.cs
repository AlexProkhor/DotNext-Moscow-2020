using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.OperationContext;

namespace HightechAngular.Shop.Features.Cart
{
    public class UpdateCartContext<TIn, TOut> : ByIntIdOperationContextBase<TIn>,
        ICommand<TOut> where TIn : class, IHasId<int>
    {
        [Required]
        public Product Product { get; }
        public UpdateCartContext(TIn request, Product product) : base(request)
        {
            Product = product;
        }
    }
}
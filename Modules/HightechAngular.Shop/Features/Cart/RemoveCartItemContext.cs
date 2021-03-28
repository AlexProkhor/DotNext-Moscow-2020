using System.ComponentModel.DataAnnotations;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.OperationContext;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveCartItemContext : UpdateCartContext<RemoveCartItem, bool>
    {
        public RemoveCartItemContext(RemoveCartItem request, Product product) : base(request, product)
    {
    }
}
}
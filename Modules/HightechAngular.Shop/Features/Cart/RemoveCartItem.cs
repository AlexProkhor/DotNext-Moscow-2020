using System.ComponentModel.DataAnnotations;
using Force.Cqrs;
using Force.Ddd;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveCartItem : HasIdBase, ICommand<bool>
    {
    }
}
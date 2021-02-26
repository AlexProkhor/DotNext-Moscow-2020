using System.ComponentModel.DataAnnotations;
using Force.Cqrs;
using Force.Ddd;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveCartItem : IHasId<int>, ICommand<bool>
    {

        public int Id { get; set; }

        object? IHasId.Id { get; } = default;
    }
}
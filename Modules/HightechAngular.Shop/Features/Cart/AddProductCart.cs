using Force.Cqrs;
using Force.Ddd;

namespace HightechAngular.Shop.Features.Cart
{
    public class AddProductCart : IHasId<int>, ICommand<int>
    {
        public int Id { get; set; }

        object? IHasId.Id { get; } = default!;
    }
}
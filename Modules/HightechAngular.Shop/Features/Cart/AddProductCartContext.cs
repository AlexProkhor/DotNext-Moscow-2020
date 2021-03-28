using HightechAngular.Orders.Entities;

namespace HightechAngular.Shop.Features.Cart
{
    public class AddProductCartContext : UpdateProductInCartContextBase<AddProductCart, int>
    {
        public AddProductCartContext(AddProductCart request, Product product) : base(request, product)
        {
        }
    }
}

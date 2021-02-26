using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class AddProductCartCommandHandler : ICommandHandler<AddProductCartContext, int>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IQueryable<Product> _products;

        public AddProductCartCommandHandler(ICartStorage cartStorage, IQueryable<Product> products)
        {
            _cartStorage = cartStorage;
            _products = products;
        }

        public int Handle(AddProductCartContext input)
        {
            var product = _products.First(x => x.Id == input.Product.Id);
            _cartStorage.Cart.AddProduct(product);
            _cartStorage.SaveChanges();
            return input.Product.Id;
        }
    }
}

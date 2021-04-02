using EFCore.BulkExtensions;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System.Collections.Generic;
using System.Linq;

namespace WorkService
{
    public class OrderDomainEventHandler : IGroupDomainEventHandler<IEnumerable<ProductPurchased>>
    {
        private readonly IQueryable<Product> _products;

        public OrderDomainEventHandler(IQueryable<Product> products)
        {
            _products = products;
        }

        public void Handle(IEnumerable<ProductPurchased> input)
        {
            var dict = input.ToDictionary(x => x.ProductId, x => x.Count);

            var res = dict.Select(x => _products
                               .Where(product => product.Id == x.Key)
                               .BatchUpdate(Product.UpdatePurchaseCountExpression(dict[x.Key])))
                           .ToList();
        }
    }
}

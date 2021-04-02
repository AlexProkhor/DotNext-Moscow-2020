using Force.Ddd.DomainEvents;
using System;

namespace WorkService
{
    public class ProductPurchased : IDomainEvent
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime Happened { get; set; }
    }
}

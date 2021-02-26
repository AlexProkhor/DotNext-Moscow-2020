using System;
using System.ComponentModel.DataAnnotations;
using Force.Extensions;
using JetBrains.Annotations;
using IntEntityBase = Infrastructure.Ddd.Domain.IntEntityBase;

namespace HightechAngular.Orders.Entities
{
    public class OrderItem: IntEntityBase
    {
        [UsedImplicitly]
        protected OrderItem()
        {
        }

        public OrderItem(Order order, CartItem cartItem)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Order = order;
            Count = cartItem.Count;
            Name = cartItem.ProductName;
            Price = cartItem.Price;
            ProductId = cartItem.ProductId;
            this.EnsureInvariant();
        }

        [Required]
        public string Name { get; protected set; } = default!;

        public virtual Order Order { get; protected set; } = default!;
        
        public double Price { get; protected set; }
        
        [Obsolete]
        public int DiscountPercent { get; protected set; }
        
        public int Count { get; protected set; }
        
        [Range(1, int.MaxValue)]
        public int ProductId { get; protected set; }
    }
}
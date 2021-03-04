using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Force.Ccc;
using Force.Ddd;
using Force.Ddd.DomainEvents;
using Force.Extensions;
using HightechAngular.Identity.Entities;
using Infrastructure.Ddd;
using Infrastructure.Ddd.Domain.State;

namespace HightechAngular.Orders.Entities
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public partial class Order : IntEntityBase
    {
        public static readonly OrderSpecs Specs = new OrderSpecs();

        protected Order()
        {
        }

        public Order(Cart cart)
        {
            User = cart.User ?? throw new InvalidOperationException("User must be authenticated");
            
            _orderItems = cart
                .CartItems
                .Select(x => new OrderItem(this, x))
                .ToList();

            Total = _orderItems.Select(x => x.Price).Sum();
            Status = OrderStatus.New;
            this.EnsureInvariant();
        }
       
        public OrderStatus BecomeShipped()
        {
            Status = OrderStatus.Shipped;
            return Status;
        }
        
        public OrderStatus BecomeDispute()
        {
            Status = OrderStatus.Dispute;
            return Status;
        }
        
        public OrderStatus BecomeComplete()
        {
            Status = OrderStatus.Complete;
            return Status;
        }

        [Required]
        public virtual User User { get; protected set; } = default!;

        public DateTime Created { get; protected set; } = DateTime.UtcNow;
        
        public DateTime Updated { get; protected set; }
        
        private List<OrderItem> _orderItems = new List<OrderItem>();
       // public IEnumerable<OrderItem> OrderItems => _orderItems;
       public virtual IEnumerable<OrderItem> OrderItems => _orderItems;
        
        public double Total { get; protected set; }
        
        public Guid? TrackingCode { get; protected set; }
        
        public OrderStatus Status { get; protected set; }
    }
}
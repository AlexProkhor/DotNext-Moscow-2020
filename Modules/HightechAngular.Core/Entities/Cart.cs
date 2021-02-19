using System;
using System.Collections.Generic;
using System.Linq;
using HightechAngular.Identity.Entities;
using Infrastructure.Ddd;

namespace HightechAngular.Orders.Entities
{
    public class Cart : EntityBase<Guid>
    {

        protected Cart()
        {

        }

        public Cart(User user)
        {
            User = user;
            Id = Guid.NewGuid();
            _cartItems = new List<CartItem>();
        }

        public Cart(Guid id, IEnumerable<CartItem> cartItems, User user)
        {
            User = user;
            Id = id;
            _cartItems = new List<CartItem>(cartItems);
        }

        public User User { get; }

        private readonly List<CartItem> _cartItems;

        public IEnumerable<CartItem> CartItems => _cartItems;


        public bool TryRemoveProduct(int productId)
        {
            var cartItem = _cartItems
                .FirstOrDefault(x => x.ProductId == productId);
            if (cartItem == null)
            {
                return false;
            }

            if (cartItem.Count > 1)
            {
                cartItem.DecrementCount();
            }
            else
            {
                _cartItems.Remove(cartItem);
            }

            return true;
        }

        public void AddProduct(Product product)
        {
            var cartItem = _cartItems
                .FirstOrDefault(x => x.ProductId == product.Id);

            if (cartItem == null)
            {
                cartItem = new CartItem(
                    product.Id,
                    product.Name,
                    product.Category.Name,
                    product.GetDiscountedPrice()
                );

                _cartItems.Add(cartItem);
            }
            else
            {
                cartItem.IncrementCount();
            }
        }

        public bool IsEmpty() => !_cartItems.Any();
    }
}
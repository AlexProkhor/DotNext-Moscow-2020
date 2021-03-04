using Force.Ccc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HightechAngular.Orders.Entities
{
    public partial class Order
    {
        public class OrderStateBase
        {

            protected Order Order { get; }
            protected OrderStateBase(Order order)
            {
                Order = order;
            }

        }

        public class NewOrderState : OrderStateBase
        {
            protected NewOrderState([NotNull] Order order) : base(order)
            {
                if (order.Status != OrderStatus.New)
                {
                    throw new ArgumentException($"Order status is {order.Status}. Expected {OrderStatus.New}");
                }
            }

            public void BecomePaid()
            {
                Order.Status = OrderStatus.Paid;
            }

        }
    }
}

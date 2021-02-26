﻿using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderContext :
        ByIntIdOperationContextBase<CompleteOrder>,
        ICommand<Task<HandlerResult<OrderStatus>>>
    {
        [Required]
        public Order Order { get; }
        public CompleteOrderContext(CompleteOrder request, Order order) : base(request)
        {
            Order = order;
        }
    }
}

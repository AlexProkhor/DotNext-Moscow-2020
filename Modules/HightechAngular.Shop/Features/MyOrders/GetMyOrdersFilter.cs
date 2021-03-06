﻿using System.Linq;
using HightechAngular.Identity.Services;
using HightechAngular.Orders.Entities;
using Infrastructure.Ddd;
using JetBrains.Annotations;

namespace HightechAngular.Shop.Features.MyOrders
{
    [UsedImplicitly]
    public class GetMyOrdersFilter : IFilter<Order, GetMyOrders> 
    {
        private readonly IUserContext _userContext;

        public GetMyOrdersFilter(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public IQueryable<Order> Filter(IQueryable<Order> queryable, GetMyOrders predicate)
        {
            var userName = _userContext.User?.UserName;
            queryable = userName == null 
                ? queryable.Where(x => false) 
                : queryable.Where(Order.Specs.ByUserName(userName));
            return queryable;
        }
    }
}
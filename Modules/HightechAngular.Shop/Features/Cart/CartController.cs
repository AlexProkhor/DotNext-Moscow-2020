using System;
using System.Collections.Generic;
using System.Net;
using Force.Extensions;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.Cart
{
    public class CartController : ApiControllerBase
    {
        [HttpGet]
        public ActionResult<List<CartItem>> Get([FromServices] ICartStorage storage) =>
            storage.Cart.CartItems.PipeTo(Ok);

        [HttpPut("Add")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult Add(
             [FromServices] Func<AddProductCart, AddProductCartContext> factory,
            [FromBody] int productId) =>
            this.Process(factory(new AddProductCart() { Id = productId }));

        [HttpPut("Remove")]
        public ActionResult<bool> Remove(
            [FromServices] Func<RemoveCartItem, RemoveCartItemContext> factory,
            [FromBody] int productId) =>
            this.Process(factory(new RemoveCartItem() { Id = productId }));
    }
}
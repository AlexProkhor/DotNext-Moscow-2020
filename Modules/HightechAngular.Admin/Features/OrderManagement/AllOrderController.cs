using System;
using System.Threading.Tasks;
using HightechAngular.Orders.Base;
using HightechAngular.Shop.Features.Cart;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderController : ApiControllerBase
    {
        [HttpGet()]
        [ProducesResponseType(typeof(OrderListItem), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllOrders query) =>
            this.Process(query);

        [HttpPut("PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PayOrder(
            [FromServices] Func<PayOrder, PayOrderContext> factory,
            [FromBody] PayOrder command) =>
            await this.ProcessAsync(factory(command));

        [HttpGet("GetOrders")]
        [ProducesResponseType(typeof(AllOrdersItem), StatusCodes.Status200OK)]
        public IActionResult GetOrders([FromQuery] GetMyOrders query) =>
            this.Process(query);

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped(
            [FromServices] Func<ChangeOrderStateBase, CompleteOrderAdminContext> factory,
            [FromBody] ShipOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromServices] Func<ChangeOrderStateBase, CompleteOrderAdminContext> factory,
            [FromBody] ChangeOrderStateBase command) =>
            await this.ProcessAsync(command);
    }
}
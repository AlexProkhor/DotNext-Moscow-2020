using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HightechAngular.Orders.Base;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class MyOrdersController : ApiControllerBase
    {
        [HttpPost("CreateNew")]
        [Authorize]
        public ActionResult<int> CreateNew([FromBody] CreateOrder query)
            => this.Process(query);

        [HttpGet("GetMyOrders")]
        public ActionResult<IEnumerable<OrderListItem>> GetMyOrders([FromQuery] GetMyOrders query) =>
            this.Process(query);

        [HttpPut("Dispute")]
        public async Task<IActionResult> Dispute(
        [FromServices] Func<DisputeOrder, DisputeOrderContext> factory,
        [FromBody] DisputeOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromServices] Func<CompleteOrder, CompleteOrderContext> factory,
            [FromBody] CompleteOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("PayOrder")]
        public async Task<IActionResult> PayOrder(
            [FromServices] Func<ChangeOrderStateBase, PayMyOrderContext> factory,
            [FromBody] ChangeOrderStateBase command) =>
            await this.ProcessAsync(command);
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class AllOrdersItem : HasIdBase
    {
        public static readonly Expression<Func<Order, AllOrdersItem>> Map = x => new AllOrdersItem()
        {
            Id = x.Id,
            Total = x.Total,
            Status = x.Status.ToString(),
            Created = x.Created.ToString("d"),
            UserId = x.User.Id
        };

        [Display(Name = "Id")]
        public override int Id { get; set; } = default!;

        [Display(Name = "Total")]
        public double Total { get; set; } = default!;

        [Display(Name = "Status")]
        public string Status { get; set; } = default!;

        [Display(Name = "Created")]
        public string Created { get; set; } = default!;

        [HiddenInput]
        public string UserId { get; set; } = default!;
    }
}
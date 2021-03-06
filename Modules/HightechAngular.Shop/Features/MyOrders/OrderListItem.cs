﻿using Force.Ddd;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class OrderListItem : HasIdBase
    {
        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = default!;

        [Display(Name = "Created")]
        public string Created { get; set; } = default!;

        [Display(Name = "UserName")]
        public string UserName { get; set; } = default!;

        [Display(Name = "Comment")]
        public string DisputeComment { get; set; } = default!;

        private const string Comment = "To do comments";
    }
}
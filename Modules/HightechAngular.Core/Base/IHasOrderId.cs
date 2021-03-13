using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HightechAngular.Orders.Base
{
    public interface IHasOrderId
    {
        [UsedImplicitly]
        int OrderId { get; }
    }
}

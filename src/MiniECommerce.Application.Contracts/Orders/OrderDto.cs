using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MiniECommerce.Orders;

public class OrderDto : AuditedEntityDto<Guid>
{
    public decimal TotalPrice { get; set; }
    public List<OrderItemDto> Items { get; set; }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniECommerce.Orders;

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }
    [Range(1,int.MaxValue,ErrorMessage ="Quantity must be at least 1!")]
    public int Quantity { get; set; }
}


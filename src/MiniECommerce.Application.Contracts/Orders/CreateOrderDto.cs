using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniECommerce.Orders;

public class CreateOrderDto
{
    [Required]
    [MinLength(1, ErrorMessage = "You must add at least one item to the order!")]
    public List<CreateOrderItemDto> Items { get; set; }
}


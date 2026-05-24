using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace MiniECommerce.Orders;

public class OrderItem : Entity<Guid>
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    private OrderItem() { }

    public OrderItem(Guid id, Guid productId, int quantity, decimal unitPrice)
        : base(id)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}

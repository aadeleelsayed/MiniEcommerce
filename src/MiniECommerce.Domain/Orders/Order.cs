using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Entities.Auditing;

namespace MiniECommerce.Orders;
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public Guid CustomerId { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }
        public decimal TotalPrice => Items.Sum(item => item.UnitPrice * item.Quantity);
    
        private Order() { }
        public Order(Guid id, Guid customerId, ICollection<OrderItem> items)
            : base(id)
        {
            CustomerId = customerId;
            Items = new Collection<OrderItem>();
        }

    public Order(Guid id) : base(id)
    {
        Items = new Collection<OrderItem>();
    }

    public void AddItem(Guid itemId,Guid productId, decimal unitPrice, int quantity)
        {
        if (quantity <= 0)
        {
            throw new BusinessException("Quantity cannot be less than or equal to zero");
        }

        var existingItem = Items.FirstOrDefault(x => x.ProductId == productId);
        if (existingItem != null)
        {
            throw new BusinessException("Item is already added to this order");
        }

        Items.Add(new OrderItem(itemId, productId, quantity, unitPrice));
    }
}


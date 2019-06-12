using System;
using Commerce.Domain.Entities.BaseModels;
using Commerce.Domain.Entities.Catalog;

namespace Commerce.Domain.Entities.Orders
{
    public class OrderItem : BaseEntity
    {
        public virtual string OrderItemGuid { get; set; } = Guid.NewGuid().ToString("N");
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
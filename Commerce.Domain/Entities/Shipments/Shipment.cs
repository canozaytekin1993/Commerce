using System;
using System.Collections.Generic;
using Commerce.Domain.Entities.BaseModels;
using Commerce.Domain.Entities.Orders;

namespace Commerce.Domain.Entities.Shipments
{
    public class Shipment : BaseEntity
    {
        private ICollection<ShipmentItem> _shipmentItems { get; set; }
        public int OrderId { get; set; }
        public string TrakingNumber { get; set; }
        public DateTime ShipmentDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public Order Order { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}
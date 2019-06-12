using Commerce.Domain.Entities.BaseModels;

namespace Commerce.Domain.Entities.Shipments
{
    public class ShipmentItem : BaseEntity
    {
        public int ShipmentId { get; set; }
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
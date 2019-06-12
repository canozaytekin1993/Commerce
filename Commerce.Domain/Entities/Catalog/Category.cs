using Commerce.Domain.Entities.BaseModels;

namespace Commerce.Domain.Entities.Catalog
{
    public class Category : BaseEntity
    {
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Commerce.Domain.Entities.BaseModels;

namespace Commerce.Domain.Entities.Catalog
{
    public class ProductCategory : BaseEntity
    {
        [Key] [Column(Order = 0)] public int ProductId { get; set; }

        [Key] [Column(Order = 1)] public int CatId { get; set; }

        #region Navigation

        public virtual Product Product { get; set; }
        public Category Category { get; set; }

        #endregion
    }
}
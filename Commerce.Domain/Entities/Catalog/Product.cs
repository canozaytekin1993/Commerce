using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Commerce.Domain.Entities.BaseModels;
using Commerce.Domain.Identity;

namespace Commerce.Domain.Entities.Catalog
{
    public class Product : BaseEntity
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region

        [ForeignKey(nameof(Person.Id))] public virtual Person ProductOwner { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        #endregion
    }
}
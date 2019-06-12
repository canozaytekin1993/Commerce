using Commerce.Domain.Entities.BaseModels;
using System;

namespace Commerce.Domain.Entities.Localizations
{
    public class Address : BaseEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? StateOrProvinceId { get; set; }

        public Country Country { get; set; }
        public StateOrProvince StateOrProvince { get; set; }
    }
}
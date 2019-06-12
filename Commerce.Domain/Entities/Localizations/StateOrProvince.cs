using Commerce.Domain.Entities.BaseModels;

namespace Commerce.Domain.Entities.Localizations
{
    public class StateOrProvince : BaseEntity
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public virtual Country Country { get; set; }
    }
}
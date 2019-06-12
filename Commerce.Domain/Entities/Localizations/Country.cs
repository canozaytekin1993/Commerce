using Commerce.Domain.Entities.BaseModels;
using System.Collections.Generic;

namespace Commerce.Domain.Entities.Localizations
{
    public class Country : BaseEntity
    {
        private ICollection<StateOrProvince> _provinces;

        public string Name { get; set; }
        public virtual ICollection<StateOrProvince> StateOrProvinces
        {
            get => _provinces ?? (_provinces = new List<StateOrProvince>());
            set => _provinces = value;
        }
    }
}
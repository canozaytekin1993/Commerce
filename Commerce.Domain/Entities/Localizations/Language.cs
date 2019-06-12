using Commerce.Domain.Entities.BaseModels;

namespace Commerce.Domain.Entities.Localizations
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
    }
}
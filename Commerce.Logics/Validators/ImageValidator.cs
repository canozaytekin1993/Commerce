using Commerce.Contracts.Validators;
using Commerce.Domain.Entities.Catalog;
using Commerce.Domain.Entities.Media;

namespace Commerce.Logics.Validators
{
    public class ImageValidator : IValidator<Image>
    {
        public bool IsValid(Image entity)
        {
            if (entity.ImageBinary.ImageBytes.Length > 0 && entity.ImageName != string.Empty) return true;
            return false;
        }
    }

    public class CategoryValidator : IValidator<Category>
    {
        public bool IsValid(Category entity)
        {
            if (entity.CategoryName != string.Empty) return true;
            return false;
        }
    }
}
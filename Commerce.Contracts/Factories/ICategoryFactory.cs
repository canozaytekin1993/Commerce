using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Domain.Entities.Catalog;

namespace Commerce.Contracts.Factories
{
    public interface ICategoryFactory : IEntityFactory<Category>
    {
        Task<Category> GetCategoryAsync(int categoryId);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> RemoveCategoryAsync(int categoryId);
        Task<bool> RemoveCategoryAsync(List<int> categoryIds);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<ICollection<Category>> GetAllCategoriesAsync();
        Task<ICollection<Category>> GetParentCategoriesAsync();
        Task<ICollection<Category>> GetChildrenCategoryAsync(int parentId);
    }
}
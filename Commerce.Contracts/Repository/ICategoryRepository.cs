using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Domain.Entities.Catalog;

namespace Commerce.Contracts.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(int catId);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> RemoveCategoryAsync(int catId);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> RemoveCategoryAsync(List<int> categories);
        Task<bool> UpdateCategoryAsync(List<Category> categories);
        Task<ICollection<Category>> GetParentCategoryAsync();
        Task<ICollection<Category>> GetCollectionCategoryAsync(int parentId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;
using Commerce.Contracts.Validators;
using Commerce.Domain.Entities.Catalog;

namespace Commerce.Logics.Managers
{
    public class CategoryManager : ICategoryRepository
    {
        private readonly ICategoryFactory _factory;
        private readonly IExceptionHandler _handler;
        private IValidator<Category> _validator;

        public CategoryManager(ICategoryFactory factory, IValidator<Category> validator, IExceptionHandler handler)
        {
            _factory = factory;
            _validator = validator;
            _handler = handler;
        }

        public async Task<Category> GetCategoryAsync(int catId)
        {
            if (catId < 0) return null;
            return await _handler.Run(() => _factory.GetCategoryAsync(catId));
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            if (category == null) return false;
            return await _handler.Run(() => _factory.AddCategoryAsync(category));
        }

        public async Task<bool> RemoveCategoryAsync(int catId)
        {
            return await _handler.Run(() => _factory.RemoveCategoryAsync(catId));
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            if (category == null) return false;
            return await _handler.Run(() => _factory.UpdateCategoryAsync(category));
        }

        public async Task<bool> RemoveCategoryAsync(List<int> categories)
        {
            if (!categories.Any()) return false;
            return await _handler.Run(() => _factory.RemoveCategoryAsync(categories));
        }

        public async Task<bool> UpdateCategoryAsync(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Category>> GetParentCategoryAsync()
        {
            return await _handler.Run(() => _factory.GetParentCategoriesAsync());
        }

        public async Task<ICollection<Category>> GetCollectionCategoryAsync(int parentId)
        {
            return await _handler.Run(() => _factory.GetChildrenCategoryAsync(parentId));
        }
    }
}
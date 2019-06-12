using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Data.Contexts;
using Commerce.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Logics.Factories
{
    public class CategoryFactory : ICategoryFactory
    {
        private readonly CommerceDbContext _db;

        public CategoryFactory(CommerceDbContext db)
        {
            _db = db;
        }

        public Task<bool> CrateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            if (_db.Categories.Any())
            {
                var categories = await _db.Categories.FindAsync(categoryId);
                if (categories != null) return categories;
            }

            return null;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            if (category != null)
            {
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveCategoryAsync(int categoryId)
        {
            if (categoryId > 1)
            {
                var category = _db.Categories.FindAsync(categoryId);
                if (category != null)
                {
                    _db.Categories.Remove(await category);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> RemoveCategoryAsync(List<int> categoryIds)
        {
            if (!categoryIds.Any()) return false;
            categoryIds.ForEach(id =>
            {
                var category = _db.Categories.FindAsync(id).Result;
                _db.Categories.Remove(category);
            });
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            if (category != null) return false;
            await _db.Categories.AddAsync(category);
            return true;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            if (!_db.Categories.Any()) return null;
            return await _db.Categories.ToListAsync();
        }

        public async Task<ICollection<Category>> GetParentCategoriesAsync()
        {
            if (!_db.Categories.Any() && !_db.Categories.Any(p => p.ParentId == null)) return null;
            return await _db.Categories.Where(p => p.ParentId != null).ToListAsync();
        }

        public async Task<ICollection<Category>> GetChildrenCategoryAsync(int parentId)
        {
            if (!_db.Categories.Any() && !_db.Categories.Where(p => p.ParentId == parentId).ToList().Any()) return null;
            return await _db.Categories.Where(p => p.ParentId == parentId).ToListAsync();
        }
    }
}
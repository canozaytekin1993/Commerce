using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Data.Contexts;
using Commerce.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Logics.Factories
{
    public class ProductFactory : IEntityFactory<Product>
    {
        private readonly CommerceDbContext _db;

        public ProductFactory(CommerceDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CrateAsync(Product entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));
            return await Task<bool>.Factory.StartNew(() =>
            {
                _db.Products.AddAsync(entity);
                _db.SaveChangesAsync();
                return true;
            });
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            if (!await _db.Products.AnyAsync()) return null;
            return await _db.Products.ToListAsync();
        }
    }
}
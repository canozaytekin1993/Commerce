using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;
using Commerce.Contracts.Validators;
using Commerce.Domain.Entities.Catalog;

namespace Commerce.Logics.Managers
{
    public class ProductManager : IProductRepository
    {
        private readonly IEntityFactory<Product> _factory;
        private readonly IExceptionHandler _handler;
        private readonly IValidator<Product> _validator;

        public ProductManager(IEntityFactory<Product> factory, IValidator<Product> validator, IExceptionHandler handler)
        {
            _factory = factory;
            _validator = validator;
            _handler = handler;
        }

        public async Task<bool> AddProduct(Product product)
        {
            if (_validator.IsValid(product)) return await _handler.Run(() => _factory.CrateAsync(product));

            return false;
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await _handler.Run(() => _factory.GetAllAsync());
        }
    }
}
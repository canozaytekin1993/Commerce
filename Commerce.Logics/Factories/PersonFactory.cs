using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Data.Contexts;
using Commerce.Domain.Identity;

namespace Commerce.Logics.Factories
{
    public class PersonFactory : IEntityFactory<Person>
    {
        private readonly CommerceDbContext _db;

        public PersonFactory(CommerceDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CrateAsync(Person entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
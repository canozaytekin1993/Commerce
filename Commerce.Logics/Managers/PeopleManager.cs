using System;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;
using Commerce.Contracts.Validators;
using Commerce.Domain.Identity;

namespace Commerce.Logics.Managers
{
    public class PeopleManager : IPersonRepository
    {
        private readonly IEntityFactory<Person> _factory;
        private readonly IExceptionHandler _handler;
        private readonly IValidator<Person> _validator;

        public PeopleManager(IEntityFactory<Person> factory, IValidator<Person> validator, IExceptionHandler handler)
        {
            _factory = factory;
            _validator = validator;
            _handler = handler;
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            if (_validator.IsValid(person))
                return _handler != null && await _handler.Run(() => _factory.CrateAsync(person));

            return false;
        }

        public Task<bool> RemovePersonAsync(string personId)
        {
            throw new NotImplementedException();
        }
    }
}
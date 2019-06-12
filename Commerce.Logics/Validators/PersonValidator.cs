using Commerce.Contracts.Validators;
using Commerce.Domain.Identity;

namespace Commerce.Logics.Validators
{
    public class PersonValidator : IValidator<Person>
    {
        public bool IsValid(Person entity)
        {
            return entity.Email != null && entity.UserName != null && entity.FirstName != null &&
                   entity.SurName != null;
        }
    }
}
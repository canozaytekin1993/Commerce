using Microsoft.AspNetCore.Identity;

namespace Commerce.Domain.Identity
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
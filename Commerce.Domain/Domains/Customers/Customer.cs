using System;
using Commerce.Domain.Identity;

namespace Commerce.Domain.Domains.Customers
{
    public class Customer : Person
    {
        public bool IsActive { get; set; }
        public DateTime AddedOn { get; set; }
        public bool HasShoppingCartItem { get; set; }
        public bool Deleted { get; set; }
    }
}
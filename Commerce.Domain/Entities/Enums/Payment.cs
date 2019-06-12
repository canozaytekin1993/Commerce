namespace Commerce.Domain.Entities.Enums
{
    public enum Payment
    {
        Pending = 10,
        Authorized = 20,
        Paid = 30,
        Refunded = 40,
        Denied = 50,
        Void = 70
    }
}
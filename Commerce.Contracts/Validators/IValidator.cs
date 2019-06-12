namespace Commerce.Contracts.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T entity);
    }
}
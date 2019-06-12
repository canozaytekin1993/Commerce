using System;

namespace Commerce.Contracts.Handlers
{
    public interface IExceptionHandler
    {
        T Run<T>(Func<T> func);
    }
}
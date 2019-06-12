using System;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;

namespace Commerce.Logics.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public T Run<T>(Func<T> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception e)
            {
                _logger.Log(e);
            }

            return default;
        }
    }
}
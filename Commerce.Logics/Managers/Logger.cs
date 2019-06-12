using System;
using Commerce.Contracts.Repository;

namespace Commerce.Logics.Managers
{
    public class Logger : ILogger
    {
        public void Log(Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}
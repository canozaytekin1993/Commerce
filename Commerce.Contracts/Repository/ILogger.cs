using System;

namespace Commerce.Contracts.Repository
{
    public interface ILogger
    {
        void Log(Exception ex);
    }
}
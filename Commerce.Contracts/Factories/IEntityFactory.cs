using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Contracts.Factories
{
    public interface IEntityFactory<T>
    {
        Task<bool> CrateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<ICollection<T>> GetAllAsync();
    }
}
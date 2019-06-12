using System.Threading.Tasks;
using Commerce.Domain.Identity;

namespace Commerce.Contracts.Repository
{
    public interface IPersonRepository
    {
        Task<bool> AddPersonAsync(Person person);
        Task<bool> RemovePersonAsync(string personId);
    }
}
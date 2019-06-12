using System.Security.Claims;
using System.Threading.Tasks;

namespace Commerce.Contracts.Factories
{
    public interface ITokenFactory
    {
        Task<string> GenerateIdentityToken(string username, ClaimsIdentity identity);
        ClaimsIdentity GenerateuserIdentity(string username, string id);
    }
}
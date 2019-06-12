using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Domain.Configurations.Auth;
using Newtonsoft.Json;

namespace Commerce.Business.Api.Extensions
{
    public static class TokenExtensions
    {
        public static async Task<string> GenerateJwtTokenAsync(ClaimsIdentity identity, ITokenFactory factory,
            string username, JwtIssuerOptions options, JsonSerializerSettings serializerSettings)
        {
            var token = new
            {
                id = identity.Claims.Single(s => s.Type == "Id").Value,
                token = await factory.GenerateIdentityToken(username, identity),
                expiration = (int) options.ValidUnit.TotalSeconds
            };
            return JsonConvert.SerializeObject(token, serializerSettings);
        }
    }
}
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Commerce.Presentation.Desktop.ViewModels.Models;
using Newtonsoft.Json;

namespace Commerce.Presentation.Desktop.Extensions
{
    public class AccountExtensions
    {
        private readonly string _uri;

        public AccountExtensions(string baseUri)
        {
            _uri = baseUri;
        }

        public async Task<TokenViewModel> LoginClientAsync(string username, string password)
        {
            using (var client = new HttpClient())
            {
                var user = new {username, password};
                var userObj = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(userObj, Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"{_uri}/api/login", content);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var token = JsonConvert.DeserializeObject<TokenViewModel>(await result.Content.ReadAsStringAsync());
                    if (token != null) return token;
                }
            }

            return null;
        }
    }
}
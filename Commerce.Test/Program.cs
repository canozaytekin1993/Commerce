using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Commerce.Test
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }

    public class TokenViewModel
    {
        [JsonProperty("token")] public string Token { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("expiration")] public string expiration { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press enter to cont...");
            Console.ReadLine();
            using (var client = new HttpClient())
            {
                #region UserLogin Testing

                //var person = new
                //{
                //    firstname = "can",
                //    surname = "ozaytekin",
                //    password = "123",
                //    confirmpassword = "123",
                //    email = "canozaytekin@gmail.com"
                //};
                //var jobj = JsonConvert.SerializeObject(person);
                //HttpContent content = new StringContent(jobj, Encoding.UTF8, "application/json");
                //var result = client.PostAsync("http://localhost:5000/api/accounts/register", content).Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    var reMessage = result.Content.ReadAsStreamAsync().Result;
                //    Console.WriteLine(reMessage);
                //}

                #endregion

                #region Token Testing

                //var pers = new
                //{
                //    username = "canozaytekin@gmail.com",
                //    password = "123"
                //};
                //var jobj = JsonConvert.SerializeObject(pers);
                //HttpContent content = new StringContent(jobj, Encoding.UTF8, "application/Json");
                //var result = client.PostAsync("http://localhost:5000/api/account/login", content).Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    var message =
                //        JsonConvert.DeserializeObject<TokenViewModel>(result.Content.ReadAsStreamAsync().Result.ToString());
                //    Console.WriteLine($"Token: {message.Token} \n Expiration: {result}");
                //    if (message.Token != null)
                //    {
                //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                //            message.Token);
                //        var results = client.GetAsync("https://localhost:5000/api/produtcs").Result;
                //        var products = results.Content.ReadAsAsync<IEnumerable<ProductViewModel>>().Result;
                //        if (products.Any()) Console.WriteLine("secure api connection established");
                //    }
                //}

                #endregion
            }

            Console.ReadLine();
        }
    }
}
using Newtonsoft.Json;

namespace Commerce.Presentation.Desktop.ViewModels.Models
{
    public class TokenViewModel
    {
        [JsonProperty("token")] public string Token { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("expiration")] public string Expiration { get; set; }
    }
}
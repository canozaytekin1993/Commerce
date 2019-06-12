using Newtonsoft.Json;

namespace Commerce.Presentation.Desktop.ViewModels.Models
{
    public class LoginViewModel
    {
        [JsonProperty("username")] public string Username { get; set; }

        [JsonProperty("password")] public string Password { get; set; }
    }
}
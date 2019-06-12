using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Commerce.Business.Api.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [JsonProperty("usrname")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
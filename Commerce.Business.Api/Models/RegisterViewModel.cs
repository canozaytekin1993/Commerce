using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Commerce.Business.Api.Models
{
    public class RegisterViewModel
    {
        [Required] [JsonProperty("firstName")] public string FirstName { get; set; }

        [Required] [JsonProperty("surName")] public string SurName { get; set; }

        [Required] [JsonProperty("password")] public string Password { get; set; }

        [Required]
        [JsonProperty("confirmpassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
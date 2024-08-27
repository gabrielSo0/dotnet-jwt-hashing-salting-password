using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hashing_salting_password.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
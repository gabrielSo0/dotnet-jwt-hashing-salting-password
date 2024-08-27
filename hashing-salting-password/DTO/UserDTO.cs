using System.ComponentModel.DataAnnotations;

namespace hashing_salting_password.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
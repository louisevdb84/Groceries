using System.ComponentModel.DataAnnotations;

namespace Groceries.API.Dtos
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using medGet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace medGet.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public Location Location { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be 4 characters or more!")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password Don't Match!")]
        public string ConfirmPassword { get; set; }
    }
}

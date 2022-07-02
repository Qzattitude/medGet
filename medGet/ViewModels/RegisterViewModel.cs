using medGet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace medGet.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Only 11 Digits are allowed")]
        public string Contact { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Only 11 Digits are allowed")]
        public int Age { get; set; }

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

using medGet.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace medGet.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MinLength(11, ErrorMessage = "Only 11 Digits are allowed")]
        [MaxLength(11, ErrorMessage = "Only 11 Digits are allowed")]
        public string? Contact { get; set; }
        public Location? Location { get; set; }

        public Gender? Gender { get; set; }

        [MaxLength(3, ErrorMessage = "You are Ghost!")]
        [MinLength(2, ErrorMessage = "You are Ghost!")]
        public int? Age { get; set; }

        public float? Height { get; set; }
        public float? Weight { get; set; }

    }
}

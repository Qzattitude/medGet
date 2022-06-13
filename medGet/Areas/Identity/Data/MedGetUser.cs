using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace medGet.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MedGetUser class
public class MedGetUser : IdentityUser
{
    
    public Guid UserId { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Username { get; set; }
    [Required]
    public int Contact { get; set; }
    [Required]
    public bool Gander { get; set; }
}


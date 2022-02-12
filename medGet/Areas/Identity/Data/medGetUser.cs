using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace medGet.Areas.Identity.Data;

// Add profile data for application users by adding properties to the medGetUser class
public class medGetUser : IdentityUser
{
    public Guid Guid { get; set; }
    public String UserName { get; set; }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AK.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AKUser class
public class AKUser : IdentityUser
{
    public string Name { get; set; }
         
}


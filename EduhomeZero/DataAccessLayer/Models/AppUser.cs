using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}

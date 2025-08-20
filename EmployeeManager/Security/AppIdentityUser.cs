using Microsoft.AspNetCore.Identity;
using System;

namespace EmployeeManager.Security
{
    public class AppIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; } 
    }
}

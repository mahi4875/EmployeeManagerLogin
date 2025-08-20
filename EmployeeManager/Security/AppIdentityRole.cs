using Microsoft.AspNetCore.Identity;

namespace EmployeeManager.Security
{
    public class AppIdentityRole :IdentityRole
    {
        public string Description {  get; set; }
    }
}

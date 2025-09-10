using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.RazorPages.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName {  get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me")]

        public bool RememberMe { get; set; }

    }
}

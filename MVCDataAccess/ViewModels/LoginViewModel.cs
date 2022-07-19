using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace MVCDataAccess.ViewModels
{
    public class LoginViewModel
    {
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl {get;set;}
        public IEnumerable<AuthenticationScheme> AllScheme {get;set;} = new List<AuthenticationScheme>();
    }
}

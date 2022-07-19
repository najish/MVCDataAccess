using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVCDataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string AadharNumber {get; set;}
    }
}
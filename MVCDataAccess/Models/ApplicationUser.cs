using Microsoft.AspNetCore.Identity;
namespace MVCDataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AadharNumber {get; set;}
    }
}
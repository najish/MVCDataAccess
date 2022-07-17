using System.ComponentModel.DataAnnotations;

namespace MVCDataAccess.ViewModels
{
    public class CreateRoleViewModel
    {
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}

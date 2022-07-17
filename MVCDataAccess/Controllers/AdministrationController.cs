using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.ViewModels;

namespace MVCDataAccess.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var list = roleManager.Roles;
            return View(list);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var role = new IdentityRole
            {
                Name = model.RoleName
            };

            var result = await roleManager.CreateAsync(role);

            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles", "Administration");
            }
            ModelState.AddModelError("","Enter Valid Email Id");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {

            var role = await roleManager.FindByIdAsync(Id);
            var model = new CreateRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(CreateRoleViewModel model)
        {
            var role = new IdentityRole { Id = model.RoleId, Name = model.RoleName };

            var result = await roleManager.UpdateAsync(role);

            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles", "Administration");
            }

            ModelState.AddModelError("", "Invalid RoleName");
            return View(model);
        }
    }
}

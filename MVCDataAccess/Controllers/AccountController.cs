using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Models;
using MVCDataAccess.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace MVCDataAccess.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AllUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    var res = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (res.Succeeded)
                        return RedirectToAction("GetStudents", "Student");
                    ModelState.AddModelError("", "Registration Failed");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var list = await signInManager.GetExternalAuthenticationSchemesAsync();
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                AllScheme = list
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if(ModelState.IsValid)
            {

                var user = await userManager.FindByEmailAsync(model.Email);

                if(user != null)
                {
                    var result = signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if(result.Result.Succeeded)
                    {
                        /*if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);*/
                        return RedirectToAction("GetStudents", "Student");
                    }
                    ModelState.AddModelError("", "Credential is wrong");
                }

                ModelState.AddModelError("", "Username is not found");

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("GetStudents", "Student");
        }

       
    }
}

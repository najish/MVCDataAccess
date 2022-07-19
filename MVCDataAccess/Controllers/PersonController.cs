using Microsoft.AspNetCore.Mvc;
namespace MVCDataAccess.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Random()
        {
            return View();
        }
    }
}
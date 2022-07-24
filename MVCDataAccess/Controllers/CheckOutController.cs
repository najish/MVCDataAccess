using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Data;

namespace MVCDataAccess.Controllers;

public class CheckOutController : Controller
{
    private readonly AppDbContext context;
    public CheckOutController()
    {
        
    }

    public IActionResult GetCheckOut()
    {
        return View();
    }
    public IActionResult Add()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }
}
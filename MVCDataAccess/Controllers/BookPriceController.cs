using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Data;

namespace MVCDataAccess.Controllers;

public class BookPriceController : Controller
{
    private readonly AppDbContext context;
    public BookPriceController(AppDbContext context)
    {
        this.context = context;
    }   
    public IActionResult GetBookPrice()
    {
        return View();
    }

    public IActionResult GetBooksPrice()
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
using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Data;

namespace MVCDataAccess.Controllers;

public class BookController : Controller
{
    private readonly AppDbContext context;
    public BookController(AppDbContext context)
    {
        this.context = context;
    }   

    public IActionResult GetBook()
    {
        return View();
    }
    public IActionResult GetBooks()
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
using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Data;

namespace MVCDataAccess.Controllers;

public class StudentController : Controller
{
    private readonly AppDbContext context;
    public StudentController(AppDbContext context)
    {   
        this.context = context;
    }

    public IActionResult GetStudent()
    {
        return View();
    }
    public IActionResult GetStudents()
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
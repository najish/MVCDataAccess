using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Data;

namespace MVCDataAccess.Controllers;

public class IssuedBookController : Controller
{
    private readonly AppDbContext context;
    public IssuedBookController(AppDbContext context)
    {
        this.context = context;
    }

    
}
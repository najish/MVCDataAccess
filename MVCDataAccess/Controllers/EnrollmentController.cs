using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Data;

namespace MVCDataAccess.Controllers;

public class EnrollmentController : Controller
{
    private readonly AppDbContext context;
    public EnrollmentController()
    {
        
    }
}
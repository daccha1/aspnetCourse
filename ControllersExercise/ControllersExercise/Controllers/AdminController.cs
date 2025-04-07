using ControllersExercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExercise.Controllers
{
    public class AdminController : Controller
    {
        
        [Route("panel/allow-access")]
        public IActionResult allowAdminAccess()
        {
            Console.WriteLine("Tekstttt");
            return Ok();
        }
    }
}

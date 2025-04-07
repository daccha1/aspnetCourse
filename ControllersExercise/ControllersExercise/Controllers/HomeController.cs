using ControllersExercise.Models;


using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ControllersExercise.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public List<User> users = new List<User>();

        [Route("users/create-new")]
        public IActionResult createUser()
        {
            int id = users.Count + 1;
            User u = new User();
            u.Id = id;
            u.FirstName = "David";
            u.LastName = "Ilic";
            u.Position = "Tester";
            users.Add(u);
            return Content("<h3>Korisnik je kreiran.</h3>", "text/html");
        }

        [Route("users/show-all")]
        public IActionResult showUsers()
        {
            return Content("Prikazani su svi korisnici");

        }

        [Route("users/delete-user")]
        public IActionResult deleteUser()
        {
            return Content("Unesite ID/Korisnik je izbrisan");
        }
        
    }
}

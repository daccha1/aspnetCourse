using Microsoft.AspNetCore.Mvc;

namespace ControllersExercise.Controllers
{
    public class ProductsController : Controller
    {
        [Route("/products/show-all")]
        public IActionResult showProducts()
        {
            return Content("Proizvodi");
        }

        [Route("products/update-stock")]
        public IActionResult changeStock()
        {
            return Content("Stanje je izmenjeno");
        }


    }
}

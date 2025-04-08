using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        // ovim se kontroler zasniva na INTERFEJSU <- Dep. inversion principle
        private readonly ICitiesService _citiesService;

        public HomeController(ICitiesService citiesService)
        {
            _citiesService = citiesService; //new CitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            string gradovi = "";

            foreach(var c in cities)
            {
                gradovi = gradovi + " " + c;
            }
            
            return Content(gradovi);
        }



    }
}

using DependencyInjectionTest.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionTest.Controllers
{
	public class MehanicarController : Controller
	{

		private readonly IMehanicarContract _mehanicarContract;

		public MehanicarController(IMehanicarContract mehanicarContract)
		{
			_mehanicarContract = mehanicarContract;
		}

		[Route("/")]
		public IActionResult Index()
		{
			return Content(_mehanicarContract.Index());
		}

		[Route("/mehanicari")]
		public IActionResult GetMehanicars()
		{
			string mehanicari = "";
			foreach(var m in _mehanicarContract.GetMehanicars())
			{
				mehanicari = mehanicari + " " + m + "\n";
			}
			return Content(mehanicari);
			
		}

		[Route("mehanicari/{id}")]
		public IActionResult PrikaziMehanicara([FromRoute] int id)
		{
			return Content(_mehanicarContract.PrikaziMehanicara(id).ToString());
		}



	}
}

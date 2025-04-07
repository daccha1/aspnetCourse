using Microsoft.AspNetCore.Mvc;
using ControllersExercise.Models;
using System.Security.Cryptography.X509Certificates;

namespace ControllersExercise.Controllers
{
    public class AccountController : Controller
    {
        public Account createAccount()
        {
            Account acc = new Account();
            return acc;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Bank application");
        }

        [Route("/account-details")]
        public IActionResult accountDetails()
        {
            Account acc = createAccount();

            return Json(acc); // returns an object in json format
        }

        [Route("/account-statement")]
        public IActionResult accountStatement()
        {
            return File("~/JorisPriprema.pdf", "application/pdf");
        }

        [Route("/get-balance/{accountNumber:int:range(1000, 1002)}/{accountState}")]
        public IActionResult getBalance([FromRoute] int accountNumber, [FromQuery] int accountState)
        {
            Account acc = createAccount();

            if(accountNumber != acc.accountNumber)
            {
                Response.StatusCode = 400;
                return Content("Account Number should be 1001");
            }

            return Content($"Current balance of the user with id: {acc.accountNumber} is: {acc.currentBalance}");
        }

        [Route("/bookstore/{bookid?}/{loggedIn?}")]
        public IActionResult book([FromQuery] int? bookid, [FromRoute] bool? loggedIn, Book book)
        {
            return Content("Tekst AJAO"); 
        }




    }
}

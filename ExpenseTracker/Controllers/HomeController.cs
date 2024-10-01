using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [SessionFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult ManageCategory()
        {
            ViewData["Title"] = "Category";
            return View();
        }

        public IActionResult Transactions()
        {
            ViewData["Title"] = "Transaction";
            return View();
        }
    }
}

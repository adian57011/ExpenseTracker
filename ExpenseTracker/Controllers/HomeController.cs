using DAL.Model;
using DAL.Repository;
using DAL.Services;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [SessionFilter]
    public class HomeController : Controller
    {
        private CategoryService _cat;

        public HomeController(CategoryService repo)
        {
            _cat = repo;
        }

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

        public async Task<JsonResult> SaveCategory(string CategoryName)
        {
            try
            {
                var model = new Category()
                {
                    Name = CategoryName,
                    CreateDate = DateTime.Now,
                    UpdateTime = DateTime.Now, 
                };

                if(await _cat.SaveCategory(model))
                {
                    return Json(new { msg = "OK" });
                }
                return Json(new { msg = "NO" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JsonResult> LoadCategory()
        {
            try
            {
                var list = await _cat.GetCategory();

                return Json(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

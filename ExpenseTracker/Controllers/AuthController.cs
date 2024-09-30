using DAL.Model;
using DAL.Services;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SubmitUser(string Username, string Password)
        {
            var model = new User()
            {
                Username = Username,
                Password = Password,
                HashedPassword = "--",
                CreatedOn = DateTime.Now,
                UpdateOn = DateTime.Now
            };

            if (await _auth.SignUp(model))
            {
                return Json(new { msg = "OK" });
            }

            return Json(new { msg = "NO" });
        }
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                {
                    return Json(new { msg = "Invalid data" });
                }

                var user = await _auth.Login(model.Username, model.Password);

                if (user.Id > 0)
                {
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return Json(new { msg = "OK" });
                }
                else
                {
                    return Json(new { msg = "NO" });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


    }
}

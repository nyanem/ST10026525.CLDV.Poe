using Microsoft.AspNetCore.Mvc;
using ST10026525.CLDV.Poe.Models;

namespace ST10026525.CLDV.Poe.Controllers
{
    public class UserController : Controller
    {
        public UserTable usrtbl = new UserTable();

        [HttpPost]
        public ActionResult About(UserTable Users)
        {
            var result = usrtbl.InsertUser(Users);
            return RedirectToAction("Home", "Home");
        }
        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

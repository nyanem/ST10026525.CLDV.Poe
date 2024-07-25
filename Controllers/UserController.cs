using Microsoft.AspNetCore.Mvc;
using ST10026525.CLDV.Poe.Models;

namespace ST10026525.CLDV.Poe.Controllers
{
    public class UserController : Controller
    {
        public UserTable usrtbl = new UserTable();

        [HttpPost]
        public ActionResult SignUp(UserTable Users)
        {
            var result = usrtbl.InsertUser(Users);
            return RedirectToAction("Home", "Home");
        }
        
    }
}

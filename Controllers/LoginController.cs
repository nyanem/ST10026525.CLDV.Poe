using Microsoft.AspNetCore.Mvc;
using ST10026525.CLDV.Poe.Models;

namespace ST10026525.CLDV.Poe.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;
        public LoginController()
       {
             login = new LoginModel();
        }

        public ActionResult Login(string password, string name)
        {
            var LoginModel = new LoginModel();
            int userID = LoginModel.SelectUser(password, name);

            // validation check if the passowrd and username are correct
            if (userID != -1)
            {
                HttpContext.Session.SetInt32("UserID", userID);
                return RedirectToAction("MyWork", "Home");
            }
            else {
                TempData["ErrorMessage"] = "Invalid name or password. Please try again!";
                return RedirectToAction("Login", "Home");
            }
          
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ST10026525.CLDV.Poe.Models;

namespace ST10026525.CLDV.Poe.Controllers
{
    public class ProductController : Controller
    {
       public productTable prodtbl = new productTable();

        [HttpGet]
        public ActionResult MyWork(productTable products) 
        {
            var result2 = prodtbl.insertProduct(products);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(prodtbl);
        }
    }
}

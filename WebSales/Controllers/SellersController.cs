using Microsoft.AspNetCore.Mvc;

namespace WebSales.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

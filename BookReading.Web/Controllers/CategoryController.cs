using Microsoft.AspNetCore.Mvc;

namespace BookReading.Web.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

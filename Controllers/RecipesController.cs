using Microsoft.AspNetCore.Mvc;

namespace SmartFridgeAPI.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

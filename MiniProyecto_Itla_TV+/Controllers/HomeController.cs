using Microsoft.AspNetCore.Mvc;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

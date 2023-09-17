using Microsoft.AspNetCore.Mvc;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class Class : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

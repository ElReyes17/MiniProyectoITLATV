using Microsoft.AspNetCore.Mvc;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

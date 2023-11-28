using Application.Interfaces.Servicios;
using Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiciosSeries _servicios;
        private readonly IServiciosProductoras _serviciosP;
        private readonly IServiciosGeneros _serviciosG;

        public HomeController(IServiciosSeries servicios, IServiciosProductoras serviciosP, IServiciosGeneros serviciosG)
        {
            _servicios = servicios;
            _serviciosG = serviciosG;
            _serviciosP = serviciosP;
        }
        public async Task<IActionResult> Index(FiltroSeriesViewModel vm)
        {
            await _serviciosG.ObtenerTodo();
            
            ViewBag.Productoras = await _serviciosP.ObtenerTodo();
            
            
            return View(await _servicios.ObtenerTodoConFiltro(vm));
        }


        public async Task<IActionResult> Video(int id)
        {            
            return View(await _servicios.ObtenerPorId(id));
        
        }


    }
}

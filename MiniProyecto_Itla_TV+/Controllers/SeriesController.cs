using Application.Interfaces.Servicios;
using Application.ViewModel.Productoras;
using Application.ViewModels.Productoras;
using Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IServiciosSeries _servicios;
        private readonly IServiciosProductoras _serviciosP;
        private readonly IServiciosGeneros _serviciosG;
        private readonly IServiciosSeriesGeneros _serviciosSeriesGeneros;

        public SeriesController(IServiciosSeries servicios, IServiciosProductoras serviciosP, IServiciosGeneros serviciosG, IServiciosSeriesGeneros serviciosSeriesGeneros)
        {
            _servicios = servicios;
            _serviciosG = serviciosG;
            _serviciosP = serviciosP;
            _serviciosSeriesGeneros = serviciosSeriesGeneros;
        }

        public async Task<IActionResult> Index() 
        {
            await _serviciosG.ObtenerTodo();
            await _serviciosP.ObtenerTodo();
            await _serviciosSeriesGeneros.ObtenerTodo();

            return View(await _servicios.ObtenerTodo());
        }


        public async Task <IActionResult> Create()
        {
            GuardarSeriesViewModel view = new GuardarSeriesViewModel();
         
            view.Productoras = await _serviciosP.ObtenerTodo();
            
            view.Generos = await _serviciosG.ObtenerTodo();
    

            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuardarSeriesViewModel crear)
        {
            if (ModelState.IsValid)
            {
              
                crear.Productoras = await _serviciosP.ObtenerTodo();
                crear.Generos = await _serviciosG.ObtenerTodo();

                return View("Create", crear);
            }

            await _servicios.Agregar(crear);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            GuardarSeriesViewModel view = await _servicios.ObtenerPorId(id);
     
            view.Productoras = await _serviciosP.ObtenerTodo();
            view.Generos = await _serviciosG.ObtenerTodo();   
            
            
            
            return View("Create", view);
        }

        [HttpPost]

        public async Task<IActionResult> EditPost(GuardarSeriesViewModel editar)
        {
            if (ModelState.IsValid)
            {
                editar.Productoras = await _serviciosP.ObtenerTodo();
                editar.Generos = await _serviciosG.ObtenerTodo();

                return View("Create", editar);
            }

            await _servicios.Actualizar(editar);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _servicios.ObtenerPorId(id));
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _servicios.EliminarPorId(id);
            return RedirectToAction("Index");
        }
    }
}

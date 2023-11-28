using Application.Interfaces.Servicios;
using Application.ViewModels.Generos;
using Application.ViewModels.Productoras;
using Microsoft.AspNetCore.Mvc;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IServiciosGeneros _servicios;

        public GenerosController(IServiciosGeneros servicios)
        {
            _servicios = servicios;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _servicios.ObtenerTodo());
        }


        public IActionResult Create()
        {
            GuardarGenerosViewModel view = new GuardarGenerosViewModel();
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuardarGenerosViewModel crear)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", crear);
            }

            await _servicios.Agregar(crear);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
          

            return View("Create", await _servicios.ObtenerPorId(id));
        }

        [HttpPost]

        public async Task<IActionResult> EditPost(GuardarGenerosViewModel editar)
        {
            if (!ModelState.IsValid)
            {
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

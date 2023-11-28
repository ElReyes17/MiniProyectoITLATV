using Application.Interfaces.Servicios;
using Application.ViewModels.Productoras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace MiniProyecto_Itla_TV_.Controllers
{
    public class ProductorasController : Controller
    {
        private readonly IServiciosProductoras _servicios;

        public ProductorasController(IServiciosProductoras servicios)
        {
            _servicios = servicios;
        }


        public async Task <IActionResult> Index()
        {
            return View(await _servicios.ObtenerTodo());
        }


        public IActionResult Create()
        {
              GuardarProductorasViewModel view =   new GuardarProductorasViewModel();
              return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuardarProductorasViewModel crear) {

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

        public async Task<IActionResult> EditPost(GuardarProductorasViewModel editar)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", editar);
            }

            await _servicios.Actualizar(editar);
            return RedirectToAction("Index");
        }




        public async Task <IActionResult> Delete(int id)
        {         
        return View( await _servicios.ObtenerPorId(id));
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _servicios.EliminarPorId(id);
            return RedirectToAction("Index");
        }
    }
}

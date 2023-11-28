using Application.Interfaces.Repositorios;
using Application.Interfaces.Servicios;
using Application.ViewModel.Generos;
using Application.ViewModels.Generos;
using DataBase.Modelos;


namespace Application.Servicios
{
    public class ServiciosGeneros : IServiciosGeneros
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        public ServiciosGeneros(IGeneroRepositorio generoRepositorio)
        {
             _generoRepositorio = generoRepositorio;
        }

        public async Task<List<GenerosViewModel>> ObtenerTodo()
        {
            var listaProductoras = await _generoRepositorio.ObtenerTodo();

            return listaProductoras.Select(genero => new GenerosViewModel
            {

                Id = genero.Id,
                Nombre = genero.Nombre,

            }).ToList();
        }

        public async Task<GuardarGenerosViewModel> ObtenerPorId(int id)
        {
            var listaProductoras = await _generoRepositorio.ObtenerPorId(id);

            GuardarGenerosViewModel nuevo = new GuardarGenerosViewModel
            {

                Id = listaProductoras.Id,
                Nombre = listaProductoras.Nombre
            };

            return nuevo;
        }
        public async Task Agregar(GuardarGenerosViewModel objeto)
        {
            var agregar = new Generos
            {
                Nombre = objeto.Nombre
            };

            await _generoRepositorio.Agregar(agregar);
        }

        public async Task Actualizar(GuardarGenerosViewModel objeto)
        {
            var actualizar = new Generos
            {
                Id = objeto.Id,
                Nombre = objeto.Nombre
            };

            await _generoRepositorio.Actualizar(actualizar);
        }

        public async Task EliminarPorId(int id)
        {
            await _generoRepositorio.EliminarPorId(id);
        }




    }
}

using Application.Interfaces.Repositorios;
using Application.Interfaces.Servicios;
using Application.ViewModel.Productoras;
using Application.ViewModels.Productoras;
using DataBase.Modelos;


namespace Application.Servicios
{
    public class ServiciosProductoras : IServiciosProductoras
    {
        private readonly IProductoraRepositorio _repositorioProductora;
        
        public ServiciosProductoras(IProductoraRepositorio repositorioProductora)
        {
            _repositorioProductora = repositorioProductora;
        }


        public async Task<List<ProductorasViewModel>> ObtenerTodo()
        {
            var listaProductoras = await _repositorioProductora.ObtenerTodo();
            
            return listaProductoras.Select(productora => new ProductorasViewModel { 
            
            Id = productora.Id,
            Nombre = productora.Nombre,
           
            }).ToList();


        }

        public async Task<GuardarProductorasViewModel> ObtenerPorId(int id)
        {
            var listaProductoras = await _repositorioProductora.ObtenerPorId(id);

           GuardarProductorasViewModel nuevo = new GuardarProductorasViewModel {

                Id = listaProductoras.Id,
                Nombre = listaProductoras.Nombre
            };

            return nuevo;
            
        }



        public async Task Agregar(GuardarProductorasViewModel objeto)
        {
            var agregar = new Productoras
            {
                
                Nombre = objeto.Nombre
            };
            
            await _repositorioProductora.Agregar(agregar);
        }

        public async Task Actualizar(GuardarProductorasViewModel objeto)
        {
            var actualizar = new Productoras
            {
                Id = objeto.Id, 
                Nombre = objeto.Nombre
            };

            await _repositorioProductora.Actualizar(actualizar);
        }


        public async Task EliminarPorId(int id)
        {
            await _repositorioProductora.EliminarPorId(id);

        }

      
      
    }
}

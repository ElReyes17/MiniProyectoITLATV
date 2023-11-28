using Application.Interfaces.Repositorios;
using Application.Interfaces.Servicios;
using Application.Repositorios;
using Application.ViewModel.Generos;
using Application.ViewModel.Series;
using Application.ViewModels.Series;
using DataBase.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Application.Servicios
{
    public class ServiciosSeries : IServiciosSeries
    {
        private readonly ISerieRepositorio _repositorioSerie;
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly ISeriesGenerosRepositorio _repositorioSeriesGeneros;
        public ServiciosSeries(ISerieRepositorio serie, IGeneroRepositorio generoRepositorio, ISeriesGenerosRepositorio repositorioSeriesGeneros)
        {
            _repositorioSerie = serie;
            _generoRepositorio = generoRepositorio;
            _repositorioSeriesGeneros = repositorioSeriesGeneros;
        }

        public async Task<List<SeriesViewModel>> ObtenerTodo()
        {
            var listaProductoras = await _repositorioSerie.ObtenerTodoConInclusion(new List<string> { "Productora", "SeriesGeneros.Generos" });


   
            
            return listaProductoras.Select(series => new SeriesViewModel
            {

                Id = series.Id,
                Nombre = series.Nombre,
                Enlace = series.Enlace,
                Imagen = series.Imagen,
                NombreProductora = series.Productora.Nombre,
                ProductoraId = series.Productora.Id,
                SeriesGeneros = series.SeriesGeneros.Where(a => a.SeriesId == series.Id).Select(a => a.Generos.Nombre).ToList()

            }).ToList();


        }

        public async Task<List<SeriesViewModel>> ObtenerTodoConFiltro(FiltroSeriesViewModel filtro)
        {
            var listaProductoras = await _repositorioSerie.ObtenerTodoConInclusion(new List<string> { "Productora", "SeriesGeneros.Generos" });

             

            var lista = listaProductoras.Select(series => new SeriesViewModel
            {

                Id = series.Id,
                Nombre = series.Nombre,
                Enlace = series.Enlace,
                Imagen = series.Imagen,
                NombreProductora = series.Productora.Nombre,
                ProductoraId = series.Productora.Id,
                SeriesGeneros = _repositorioSeriesGeneros.ObtenerListaGeneros(series.Nombre)

            }).ToList();



            if (filtro.ProductoraId != null)
                        {
                            lista = lista.Where(series => series.ProductoraId == filtro.ProductoraId.Value).ToList();
                        } 

                        if(filtro.NombreSerie != null)
                        {
                            lista = lista.Where(series => series.Nombre == filtro.NombreSerie.ToString()).ToList();
                        } 

                        return lista;   


        }





        public async Task<GuardarSeriesViewModel> ObtenerPorId(int id)
        {
           
            var lista = await _repositorioSerie.ObtenerPorId(id);



            GuardarSeriesViewModel nuevo = new GuardarSeriesViewModel
            {

                Id = lista.Id,
                Nombre = lista.Nombre,
                Enlace = lista.Enlace,
                Imagen = lista.Imagen,
                ProductoraId = lista.ProductoraId,
                GeneroId1 = await _repositorioSeriesGeneros.ObtenerGenero1(id),
                GeneroId2 = await _repositorioSeriesGeneros.ObtenerGenero2(id)
                
            };

            return nuevo;

        }
       
        



        public async Task Agregar(GuardarSeriesViewModel objeto)
        {
            

            var agregar = new Series
            {

                Nombre = objeto.Nombre,
                Enlace = objeto.Enlace,
                Imagen = objeto.Imagen,
                ProductoraId= objeto.ProductoraId
              
                
            };

            await _repositorioSerie.Agregar(agregar);
  
          
            var serie1 = await _repositorioSerie.ObtenerPorId(agregar.Id);

            var genero1 = new SeriesGeneros
            {
               SeriesId = serie1.Id,
               GenerosId = objeto.GeneroId1
               
            };
            var genero2 = new SeriesGeneros
            {
                SeriesId = serie1.Id,
                GenerosId = objeto.GeneroId2
            };

          await _repositorioSeriesGeneros.Agregar(genero1);
            await _repositorioSeriesGeneros.Agregar(genero2);


        }

        public async Task Actualizar(GuardarSeriesViewModel objeto)
        {
            var actualizar = new Series
            {
                Id = objeto.Id,
                Nombre = objeto.Nombre,
                Enlace = objeto.Enlace,
                Imagen = objeto.Imagen,
                ProductoraId = objeto.ProductoraId,
               
            };

            await _repositorioSerie.Actualizar(actualizar);
         

            var generoactualizado = await _repositorioSeriesGeneros.ObtenerSeriesGeneros(objeto.Id);

            foreach(var generoseries in  generoactualizado)
            {
                
                await _repositorioSeriesGeneros.Eliminar(generoseries);
           
            }     

            var serie1 = await _repositorioSerie.ObtenerPorId(actualizar.Id);

            var genero1 = new SeriesGeneros
            {
                SeriesId = serie1.Id,
                GenerosId = objeto.GeneroId1

            };
            var genero2 = new SeriesGeneros
            {
                SeriesId = serie1.Id,
                GenerosId = objeto.GeneroId2
            };

            await _repositorioSeriesGeneros.Agregar(genero1);
            await _repositorioSeriesGeneros.Agregar(genero2);

        }


        public async Task EliminarPorId(int id)
        {
            await _repositorioSerie.EliminarPorId(id);

        }




    }
}

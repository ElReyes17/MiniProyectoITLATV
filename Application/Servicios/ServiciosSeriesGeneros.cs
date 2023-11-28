using Application.Interfaces.Repositorios;
using Application.Interfaces.Servicios;
using Application.Repositorios;
using Application.ViewModel.Generos;
using Application.ViewModel.Productoras;
using Application.ViewModel.Series;
using Application.ViewModels.Productoras;
using Application.ViewModels.SeriesGeneros;
using DataBase.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class ServiciosSeriesGeneros : IServiciosSeriesGeneros
    {
        private readonly ISeriesGenerosRepositorio _repositorioSeriesGeneros;

        public ServiciosSeriesGeneros( ISeriesGenerosRepositorio repositorioSeriesGeneros)
        {
            _repositorioSeriesGeneros = repositorioSeriesGeneros;
        }


        public async Task<List<SeriesGenerosViewModel>> ObtenerTodo()
        {
            var listaProductoras = await _repositorioSeriesGeneros.ObtenerTodo();
            
            return listaProductoras.Select(series => new SeriesGenerosViewModel
            {

               NombreGenero = series.Generos.Nombre,
     


            }).ToList();

        }

       

        public async Task Agregar(GuardarSeriesGenerosViewModel objeto)
        {
            var agregar = new SeriesGeneros
            {
                GenerosId = objeto.GenerosId,
                SeriesId = objeto.SeriesId,
            };

            await _repositorioSeriesGeneros.Agregar(agregar);
            
        }

     


    }
}

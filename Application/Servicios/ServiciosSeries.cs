using Application.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class ServiciosSeries
    {
        private readonly ISerieRepositorio _repositorioSerie;
        public ServiciosSeries(ISerieRepositorio serie)
        {
            _repositorioSerie = serie;
        }




    }
}

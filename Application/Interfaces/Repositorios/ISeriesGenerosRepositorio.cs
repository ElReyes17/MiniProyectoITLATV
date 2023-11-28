using DataBase.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositorios
{
     public interface ISeriesGenerosRepositorio : IMantenimientoRepositorio<SeriesGeneros>
    {

       Task <List<SeriesGeneros>> ObtenerSeriesGeneros(int id);

        Task Eliminar(SeriesGeneros seriesGeneros);

        Task<int> ObtenerGenero1(int id);

        Task<int> ObtenerGenero2(int id);

        List<string> ObtenerListaGeneros(string id);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositorios
{
    public interface IRepositorioSeries<T>
    {

        Task<List<T>> ObtenerTodo();

        Task<T> ObtenerPorId(int id);

        Task Agregar(T objeto);

        Task Actualizar(T objeto);

        Task EliminarPorId(int id);


    }
}

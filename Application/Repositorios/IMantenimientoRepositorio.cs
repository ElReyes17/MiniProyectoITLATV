using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositorios
{
    public interface IMantenimientoRepositorio<T> 
    {

        public List<T> ObtenerTodo();

        public void Agregar(T objeto);

        public void Actualizar(T objeto);

        public void EliminarPorId(int id);


    }
}

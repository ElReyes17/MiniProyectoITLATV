using DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositorios
{
    public class MantenimientoRepostorio<T> : IRepositorioSeries<T> where T : class
    {
        private readonly TVContext _contexto;
        
        private readonly DbSet<T> _dbSet;

        public MantenimientoRepostorio(TVContext contexto)
        {
            _contexto = contexto; 
            _dbSet = _contexto.Set<T>();
        }

        public async Task<List<T>> ObtenerTodo()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Agregar(T objeto)
        {
            await _dbSet.AddAsync(objeto);
            await _contexto.SaveChangesAsync();
        }
        public async Task Actualizar(T objeto)
        {
            throw new NotImplementedException();
        }

       

        public async Task EliminarPorId(int id)
        {
            throw new NotImplementedException();
        }

       
       
    }
}

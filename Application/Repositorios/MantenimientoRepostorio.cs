using Application.Interfaces.Repositorios;
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
    public class MantenimientoRepostorio<T> : IMantenimientoRepositorio<T> where T : class
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
                   
          var busqueda = await _dbSet.FindAsync(id);
           if (busqueda != null)
            {
                return busqueda;
            }

            throw new Exception("El ID INGRESADO no existe en la base de datos");
        }

        public async Task Agregar(T objeto)
        {
            await _dbSet.AddAsync(objeto);
            await _contexto.SaveChangesAsync();
        }

        public async Task Actualizar(T objeto)
        {
            _dbSet.Entry(objeto).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

       

        public async Task EliminarPorId(int id)
        {
              var delete = await _dbSet.FindAsync(id);


            if (delete != null)
            
            {
                _dbSet.Remove(delete);
                await _contexto.SaveChangesAsync();
            }
        }

       
       
    }
}

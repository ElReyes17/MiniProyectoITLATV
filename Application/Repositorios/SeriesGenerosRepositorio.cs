using Application.Interfaces.Repositorios;
using DataBase;
using DataBase.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositorios
{
    public class SeriesGenerosRepositorio : MantenimientoRepostorio<SeriesGeneros>, ISeriesGenerosRepositorio
    {

        private readonly TVContext _tVContext;
        public SeriesGenerosRepositorio(TVContext contexto) : base(contexto) {
        
            _tVContext = contexto;
        
        }

        public async Task<List<SeriesGeneros>> ObtenerSeriesGeneros(int id)
        {
         
            var generos = await _tVContext.SeriesGeneros.Where(a => a.SeriesId == id).ToListAsync();
         
             return generos;
        } 


        public async Task Eliminar(SeriesGeneros serie)
        {
             _tVContext.Set<SeriesGeneros>().Remove(serie);
            await _tVContext.SaveChangesAsync();
        }

        public async Task<int> ObtenerGenero1(int id)
        {

            var obtener = await ObtenerSeriesGeneros(id);

            var genero1 = obtener.Select(g => g.GenerosId).FirstOrDefault();

            return genero1;
        }

        public async Task<int> ObtenerGenero2(int id)
        {
            var obtener = await ObtenerSeriesGeneros(id);

            var genero2 = obtener.Select(g => g.GenerosId).Skip(1).FirstOrDefault();

            return genero2;
        }

        public List<string> ObtenerListaGeneros(string serie)
        {
            var lista = _tVContext.SeriesGeneros.Where(a=> a.Series.Nombre == serie).Select(g => g.Generos.Nombre).ToList();

            return lista;
        }


    }
}

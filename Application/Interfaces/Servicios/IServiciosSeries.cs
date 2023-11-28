using Application.ViewModel.Series;
using Application.ViewModels.Series;

namespace Application.Interfaces.Servicios
{
    public interface IServiciosSeries 
    {
        Task<List<SeriesViewModel>> ObtenerTodo();

        Task<GuardarSeriesViewModel> ObtenerPorId(int id);

        Task Agregar(GuardarSeriesViewModel objeto);

        Task Actualizar(GuardarSeriesViewModel objeto);

        Task EliminarPorId(int id);

        Task<List<SeriesViewModel>> ObtenerTodoConFiltro(FiltroSeriesViewModel filtro);


    }
}

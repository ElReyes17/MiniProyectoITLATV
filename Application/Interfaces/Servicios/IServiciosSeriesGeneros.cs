using Application.ViewModel.Generos;
using Application.ViewModels.SeriesGeneros;

namespace Application.Interfaces.Servicios
{
    public interface IServiciosSeriesGeneros
    {

        Task<List<SeriesGenerosViewModel>> ObtenerTodo();

        Task Agregar(GuardarSeriesGenerosViewModel objeto);

       

    }
}

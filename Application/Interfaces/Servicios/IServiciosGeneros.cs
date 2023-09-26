using Application.ViewModel.Generos;
using Application.ViewModels.Generos;

namespace Application.Interfaces.Servicios
{
    public interface IServiciosGeneros 
    {
        Task<List<GenerosViewModel>> ObtenerTodo();

        Task<GenerosViewModel> ObtenerPorId(int id);

        Task Agregar(GuardarGenerosViewModel objeto);

        Task Actualizar(GuardarGenerosViewModel objeto);

        Task EliminarPorId(int id);

    }
}

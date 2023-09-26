using Application.Interfaces.Repositorios;
using Application.ViewModel.Generos;
using Application.ViewModel.Productoras;
using Application.ViewModels.Productoras;
using DataBase.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Servicios
{
    public interface IServiciosProductoras 
    {
        Task<List<ProductorasViewModel>> ObtenerTodo();

        Task<GuardarProductorasViewModel> ObtenerPorId(int id);

        Task Agregar(GuardarProductorasViewModel objeto);

        Task Actualizar(GuardarProductorasViewModel objeto);

        Task EliminarPorId(int id);

    }
}

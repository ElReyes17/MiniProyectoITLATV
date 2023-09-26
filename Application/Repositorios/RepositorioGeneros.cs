using Application.Interfaces.Repositorios;
using DataBase;
using DataBase.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositorios
{
    public class RepositorioGeneros : MantenimientoRepostorio<Generos>, IGeneroRepositorio
    {
        public RepositorioGeneros(TVContext contexto) : base (contexto) {}

    }
}

using Application.Interfaces.Repositorios;
using DataBase;
using DataBase.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositorios
{
    public class RepositorioSeries : MantenimientoRepostorio<Series>, ISerieRepositorio
    {
   


        public RepositorioSeries(TVContext contexto) : base(contexto) { }
        


       

    }
}

using Application.ViewModel.Generos;
using Application.ViewModels.SeriesGeneros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Series
{
    public class SeriesViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;     

        public string Imagen { get; set; } = null!; 

        public string Enlace { get; set; } = null!;

        public string NombreProductora {get; set;} = null!;

        public int ProductoraId { get; set; }

        public List<string> SeriesGeneros { get; set; } = null!;

        public string Genero1 {get; set;} = null!;

        public string Genero2 {get; set;} = null!;
    }
}

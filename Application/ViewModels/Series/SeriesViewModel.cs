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

        public string Productora {get; set;} = null!;

        public string Genero1 {get; set;} = null!;

        public string Genero2 {get; set;} = null!;
    }
}

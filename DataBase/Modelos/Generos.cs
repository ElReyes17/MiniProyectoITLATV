using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelos
{
    public class Generos
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        
        
        //Navegacion

        public ICollection<SeriesGeneros> Propiedad_Navegacion { get; set; }

    }
}

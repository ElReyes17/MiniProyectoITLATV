using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelos
{
    public class Series
    {
        public int Id { get; set; }

        public string Nombre { get; set; }    

        public string Imagen { get; set; }

        public string Enlace { get; set; }

       
        //Relaciones
        public int ProductoraId { get; set; }

        public int GenerosId { get; set; }

        //Navegacion 

        public ICollection<SeriesGeneros> Propiedad_Navegacion { get; set; }


    }
}

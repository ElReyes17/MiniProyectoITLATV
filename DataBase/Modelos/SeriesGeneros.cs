using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelos
{
    public class SeriesGeneros
    {

        public int SeriesId { get; set; }

        public Series Series { get; set; }

        public int GenerosId { get; set; }

        public Generos Generos { get; set; }

        

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelos
{
    public class Productoras
    {

        public int Id { get; set; } 
        public string Nombre { get; set; } = null!;



        public ICollection<Series> Series { get; set; } = null!;

       

        

    }
}
using DataBase.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   public class TVContext : DbContext
    {
        public TVContext(DbContextOptions<TVContext> opciones) : base(opciones){ }

        public DbSet<Series> Series { set; get; }

        public DbSet<Generos> Generos { set; get; }

        public DbSet<SeriesGeneros> SeriesGeneros { set; get; }

        public DbSet<Productoras> Productoras { set; get; }

    }
}

using DataBase.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
   public class TVContext : DbContext
    {
        public TVContext(DbContextOptions<TVContext> opciones) : base(opciones){ }

        public DbSet<Series> Series { set; get; }

        public DbSet<Generos> Generos { set; get; }

        public DbSet<Productoras> Productoras { set; get; }

        public DbSet<SeriesGeneros> SeriesGeneros { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api


            #region tablas
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Generos>().ToTable("Generos");
            modelBuilder.Entity<Productoras>().ToTable("Productoras");
            modelBuilder.Entity<SeriesGeneros>().ToTable("SeriesGeneros");
            #endregion

            #region "llaves primarias"
            modelBuilder.Entity<Series>().HasKey(a => a.Id);
            modelBuilder.Entity<Generos>().HasKey(a => a.Id);
            modelBuilder.Entity<Productoras>().HasKey(a => a.Id);
            modelBuilder.Entity<SeriesGeneros>().HasKey(a => new {a.SeriesId, a.GenerosId});
            #endregion

            #region relaciones
            modelBuilder.Entity<Productoras>()
                .HasMany<Series>(productoras => productoras.Series)
                .WithOne(series => series.Productora)
                .HasForeignKey(productoras => productoras.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeriesGeneros>()
                .HasOne(SeriesGeneros => SeriesGeneros.Series)
                .WithMany(a => a.SeriesGeneros)
                .HasForeignKey(SeriesGeneros => SeriesGeneros.SeriesId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeriesGeneros>()
                 .HasOne(SeriesGeneros => SeriesGeneros.Generos)
                 .WithMany(a => a.SeriesGeneros)
                 .HasForeignKey(SeriesGeneros => SeriesGeneros.GenerosId)
                 .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region configuracion de campos

            #region "Series"
            modelBuilder.Entity<Series>().Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(64);

           

            #endregion

            #region "Generos"
            #endregion

            #region "Productoras"
            #endregion



            #endregion







        }

    }
}

namespace DataBase.Modelos
{
    public class Series
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;     

        public string Imagen { get; set; } = null!; 

        public string Enlace { get; set; } = null!;

       
        //Relaciones
        public int ProductoraId { get; set; }

        public Productoras Productora { get; set; } = null!;

       
        //Navegacion 

        public ICollection<SeriesGeneros> SeriesGeneros { get; set; } = null!;


    }
}

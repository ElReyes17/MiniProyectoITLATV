namespace DataBase.Modelos
{
    public class SeriesGeneros
    {

        public int SeriesId { get; set; }

        public Series Series { get; set; } = null!;



        public int GenerosId { get; set; }

        public Generos Generos { get; set; } = null!;

        

    }
}

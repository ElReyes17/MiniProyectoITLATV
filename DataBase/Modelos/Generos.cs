
namespace DataBase.Modelos
{
    public class Generos
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        
        
        //Navegacion

        public ICollection<SeriesGeneros> SeriesGeneros { get; set; } = null!;

    }
}

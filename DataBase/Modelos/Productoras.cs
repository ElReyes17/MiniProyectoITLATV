
namespace DataBase.Modelos
{
    public class Productoras
    {

        public int Id { get; set; } 
        public string Nombre { get; set; } = null!;
      
          
        public ICollection<Series> Series { get; set; } = null!;

       

        

    }
}

using Application.ViewModel.Generos;
using Application.ViewModel.Productoras;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Series
{
    public class GuardarSeriesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Introducir el nombre")]
        public string Nombre { get; set; } = null!;
        
        
        [Required(ErrorMessage = "Debe Colocar el directorio de la imagen")]
        public string Imagen { get; set; } = null!;

        [Required(ErrorMessage = "Debe Colocar el Enlace")]
        public string Enlace { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Debe Colocar aunque sea un Genero")]
        public int GeneroId1 { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe Colocar aunque sea un Genero")]
        public int GeneroId2 { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe Colocar una Productora")]
        public int ProductoraId { get; set; }

        public List<GenerosViewModel> Generos { get; set; } = null!;

        public List<ProductorasViewModel> Productoras { get; set; } = null!;

     
    }
}

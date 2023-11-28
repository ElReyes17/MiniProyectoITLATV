using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Productoras
{
    public class GuardarProductorasViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Introducir el nombre")]
        public string Nombre { get; set; } = null!;

    }
}

using System.ComponentModel.DataAnnotations;

namespace PinedaStore.Models
{
    public class contactanosModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string nombre {  get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string correo { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string mensaje { get; set; }






    }
}

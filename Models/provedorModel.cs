using System.ComponentModel.DataAnnotations;

namespace PinedaStore.Models
{
    public class provedorModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string empresa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string correo { get; set; }

       
    }
}

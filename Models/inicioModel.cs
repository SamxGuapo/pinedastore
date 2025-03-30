using System.ComponentModel.DataAnnotations;

namespace PinedaStore.Models
{
    public class inicioModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string Usuario { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Contraseña { get; set; }

    }
}

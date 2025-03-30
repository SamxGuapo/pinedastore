using System.ComponentModel.DataAnnotations;

namespace PinedaStore.Models
{
    public class registromodel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string correo { get; set; }
        public string usuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string contraseña { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string confirmarC { get; set; }


    }
}

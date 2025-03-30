using System.ComponentModel.DataAnnotations;

namespace PinedaStore.Models
{
    public class AdministradorModel
    {
        [Required(ErrorMessage ="Por favor, selecciona una imagen.")]
        [DataType(DataType.Upload)]
        public string idProducto { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set;}
        public string precio { get; set;}
        public string Unidades { get; set;}
        public string Estado { get; set; }
        public string SeleccionarI { get;set;}
        public string urlimagen { get; set;}

        public string provedor { get; set; }
    }
    
}

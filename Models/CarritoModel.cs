namespace PinedaStore.Models
{
    public class Producto
    {
        
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }

        public string Codigo {  get; set; }

    }

    public class carroitem
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }

    public class productoSeleccionados
    {
        public List<carroitem> Items { get; set; } = new List<carroitem>();
        public decimal TotalPrecio => Items.Sum(item => item.producto.precio * item.cantidad);
    }
}

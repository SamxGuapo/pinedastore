using Microsoft.AspNetCore.Mvc.Formatters;
using PinedaStore.Models;
using System.Text.Json;

namespace PinedaStore.Servicios
{
    public interface IcarritoServicio
    {
        void actualizarItemCarro(int productoId, int cantidad);
        void agregar(Producto producto, int cantidad);
        void eliminarItemCarro(int productoId);
        List<carroitem> ListarItemsCarro();
    }

    public class carritoServicio : IcarritoServicio
    {
        private readonly productoSeleccionados _productoSeleccionados;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string cnx;
        public carritoServicio(productoSeleccionados _productoSeleccionados, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _productoSeleccionados = _productoSeleccionados;
        }

        private productoSeleccionados obtenerItemsSesion()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("carrito");
            return string.IsNullOrEmpty(cartJson)
                ? new productoSeleccionados()
                : JsonSerializer.Deserialize<productoSeleccionados>(cartJson);
        }

        private void guardarItemsSesion(productoSeleccionados cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("carrito", JsonSerializer.Serialize(cart));
        }

        public void agregar(Producto producto, int cantidad)
        {
            var cart = obtenerItemsSesion();
            var existingItem = cart.Items.FirstOrDefault(i => i.producto.Codigo == producto.Codigo);
            if (existingItem != null)
            {
                existingItem.cantidad += cantidad;
            }
            else
            {
                cart.Items.Add(new carroitem { producto = producto, cantidad = cantidad });
            }
            guardarItemsSesion(cart);
        }

        public void eliminarItemCarro(int productoId)
        {
            var cart = obtenerItemsSesion();
            var item = cart.Items.FirstOrDefault(i => i.producto.Codigo == productoId.ToString());

            if (item != null)
            {
                cart.Items.Remove(item);
                guardarItemsSesion(cart);
            }
        }

        public List<carroitem> ListarItemsCarro()
        {
            return obtenerItemsSesion().Items;
        }

        public decimal obtenerTotal()
        {
            return _productoSeleccionados.TotalPrecio;
        }
        public void actualizarItemCarro(int productoId, int cantidad)
        {
            var cart = obtenerItemsSesion();
            var existeItem = cart.Items.FirstOrDefault( i => i.producto.Codigo == productoId.ToString());
            if (existeItem != null)
            {
                existeItem.cantidad = cantidad;

            }
            guardarItemsSesion(cart);
        }

       

        
        

       

       
    }
}

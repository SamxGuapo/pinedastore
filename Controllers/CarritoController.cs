using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;

namespace PinedaStore.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IcarritoServicio _carritoServicio;
        private readonly IRepositorioProducto _productoRepositorio;
        public readonly IRepositorioProducto repoProducto;

        public CarritoController(IcarritoServicio carritoservicio , IRepositorioProducto productoRepositorio, IRepositorioProducto _repoProducto)
        {
            _carritoServicio = carritoservicio;
            _productoRepositorio = productoRepositorio;
            repoProducto = _repoProducto;   

            
        }

        public ActionResult agregar(Producto productoId, int Cantidad) 
        {
           
            if (productoId != null)
            {
                _carritoServicio.agregar(productoId, Cantidad);
            }
            var carritoItems = _carritoServicio.ListarItemsCarro();
            return View("~/Views/Carrito.cshtml",carritoItems);
        }

        public IActionResult eliminar(int ProductoId)
        {
            _carritoServicio.eliminarItemCarro(ProductoId);
            var carritoItems = _carritoServicio.ListarItemsCarro();
            return View("~/Views/Carrito/Carrito.cshtml", carritoItems);
        }

        public IActionResult actualizarItem(int ProductoId, int Cantidad)
        {
            if (Cantidad < 1)
            {
                return BadRequest("La cantidad debe ser al menos 1.");}

            _carritoServicio.actualizarItemCarro(ProductoId, Cantidad);
            var carritoItems = _carritoServicio.ListarItemsCarro();

            return View("~/Views/Carrito/Carrito.cshtml", carritoItems);
            
            
        }
        public IActionResult Carrito( int productoId, int cantidad)
        {
            var conectar = repoProducto.agregar(productoId, cantidad);
            if(conectar != null)
            {
                _carritoServicio.agregar(conectar, cantidad);
            }
            var carroitem = _carritoServicio.ListarItemsCarro();
            
            
            
            
            return View("~/Views/Carrito/Carrito.cshtml", carroitem); 

        }

    }
}

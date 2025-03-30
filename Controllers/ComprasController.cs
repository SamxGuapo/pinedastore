using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;

namespace PinedaStore.Controllers
{
    public class ComprasController : Controller
    {
        public readonly IRepositorioCompras repoCompra;
       

        public ComprasController(IRepositorioCompras RepositorioCompras)
        {
            this.repoCompra = RepositorioCompras;
        }
        public IActionResult Compras()
        {
            return View("~/Views/Compras/Compras.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> comprarproducto(string Codigo)
        {
            var producto = await repoCompra.compras(Codigo);
            if (producto == null)
            { return NotFound(); }
            return Json(producto);
        }
        

        [HttpPost]
        public async Task<IActionResult>Borrar(int Codigo)
        {
            await repoCompra.BorrarProducto(Codigo);
            return View("~/Views/Carrusel/slider.cshtml");
        }
    }
}

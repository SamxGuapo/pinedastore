using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;

namespace PinedaStore.Controllers
{
    public class CarruselController : Controller
    {
        private readonly IRepositorioHome repohome;

        public CarruselController(IRepositorioHome repositoriohome)
        {
            this.repohome = repositoriohome;
        }
        public IActionResult slider()
        {
            IEnumerable<AdministradorModel> productos = repohome.ListarProductos();
            return View("~/Views/Carrusel/slider.cshtml" , productos);
        }

        [HttpGet]
        public JsonResult DetalleProducto(int id)
        {
            AdministradorModel detalle = repohome.DetalleProducto
                (id);
            return Json(detalle);
        }

    }
}

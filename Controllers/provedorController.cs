using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Contracts;

namespace PinedaStore.Controllers
{
    public class provedorController : Controller
    {
        private readonly IRepositorioProvedor repositorioProvedor1;
       
        public provedorController (IRepositorioProvedor repositorioProvedor1)
        {
            this.repositorioProvedor1 = repositorioProvedor1;
        }

        public IActionResult provedores(provedorModel provedor)
        {
            if(!ModelState.IsValid)
                return View("~/Views/Provedores/provedores.cshtml");

            repositorioProvedor1.provedor(provedor);
            TempData["SuccessMessage"] = "Datos guardados exitosamente.";
            return View("~/Views/Provedores/provedores.cshtml");
        }

        //[HttpGet]
        //public JsonResult DetalleProvedor(int idprovedor)
        //{
        //    AdministradorModel detalle = provedorModel.DetalleProvedor
        //        (idprovedor);
        //    return Json(detalle);
        //}

    }
}

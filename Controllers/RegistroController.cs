using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;

namespace PinedaStore.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IRepositorioUsuario reporegistro;
        public RegistroController(IRepositorioUsuario Reporegistro)
        {
            this.reporegistro = Reporegistro;
           
        }

        public IActionResult Registro(registromodel guardar)
        {

            if (!ModelState.IsValid)
            {
                return View("Registro");
            }
                encryptar clave = new encryptar();
            guardar.contraseña = clave.Encrypt(guardar.contraseña);

            reporegistro.registrarusuario(guardar);
            TempData["SuccessMessage"] = "Datos guardados exitosamente.";
            return View("~/Views/Usuario/Registro.cshtml");
        }
    }
}

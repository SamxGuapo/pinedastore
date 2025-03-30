using Microsoft.AspNetCore.Mvc;

namespace PinedaStore.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;



namespace PinedaStore.Controllers
{
    public class ContactanosController: Controller
    {

    
        private readonly IRepositorioUsuario repocontactanos;
      public ContactanosController(IRepositorioUsuario Repocontactanos)
      {
        this.repocontactanos = Repocontactanos;
      }
        public IActionResult Contactanos()
        {
            return View();
        }

        public IActionResult VContactanos(contactanosModel guardarC)
        {

            if (!ModelState.IsValid)
            {
                return View("~/Views/Contactanos/Contactanos.cshtml", guardarC);
            }
            repocontactanos.contactanosModel(guardarC);
            TempData["SuccessMessage"] = "Datos guardados exitosamente.";
            return View("~/Views/Contactanos/Contactanos.cshtml");
        }
    





    }





    
}

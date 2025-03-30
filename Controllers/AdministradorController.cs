using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;
using System.Linq.Expressions;

namespace PinedaStore.Controllers
{
    public class AdministradorController : Controller
    {
        
        public readonly IRepositorioProducto repoProducto;
        
        
        

        public AdministradorController(IRepositorioProducto repoProducto)
        {
            
            this.repoProducto = repoProducto;
        }

        public async Task<IActionResult> productos(AdministradorModel model)
        {
            try
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    var nuevoNombre = Guid.NewGuid().ToString() + extension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagenProdu", nuevoNombre);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    model.urlimagen= "/ImagenProdu/"+ nuevoNombre;
                    repoProducto.AdministradorModel(model);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            TempData["SuccessMessage"] = "Datos guardados exitosamente.";
            return View();
           
           

        }
        







    }
}

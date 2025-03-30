using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinedaStore.Models;
using PinedaStore.Servicios;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace PinedaStore.Controllers
{
    

    
       
    public class InicioController : Controller
    {
        private readonly IRepositorioUsuario repologin;
        private readonly IRepositorioHome repositorioHome;
        public InicioController(IRepositorioUsuario Repologin, IRepositorioHome repositorioHome)
        {
            this.repologin = Repologin;
            this.repositorioHome = repositorioHome;
            
        }

        public IActionResult Index(inicioModel guardarL)
        {
            return View("~/Views/login/Index.cshtml",guardarL);
        }

        //public IActionResult inicio(inicioModel guardarI)
        //{
        //    return View(guardarI);
        //}

        [HttpPost]
        public async Task<IActionResult> ingresar(inicioModel Index)
        {
            ErrorViewModel errormodel = new ErrorViewModel();








            try
            {
                encryptar clave = new encryptar();
                Index.Contraseña = clave.Encrypt(Index.Contraseña);
                bool rsp = await repologin.validarusuario(Index);
                if (rsp)
                {
                    return View("~/Views/Administrador/productos.cshtml");

                }
                return View("~/Views/Login/Index.cshtml");
            }
            catch (Exception Error)
            {
                errormodel.RequestId = Error.HResult.ToString();
                errormodel.message = Error.HResult.ToString();
            }
            return View("Error", errormodel);



        }




    }
}

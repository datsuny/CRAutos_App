using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Controllers
{
  
    public class IniciarSesionController : Controller
    {
        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Vendedor vendedor)
        {
            try
            {

                BuscarUsuario logear = new BuscarUsuario();

                var respuestaLogin = logear.ValidarUsuario(vendedor);

                if (respuestaLogin == null)
                {
                    ViewBag.Error = "Usuario o contraseña no valida";
                    return View();
                }
                else
                {
                    Session["VendedorLogeado"] = respuestaLogin;
                }
                return RedirectToAction("Index", "Home"); //Ejemplo debe retornar a la pantalla de publicaciones

            }
            catch (Exception )
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }

        }
    }
}
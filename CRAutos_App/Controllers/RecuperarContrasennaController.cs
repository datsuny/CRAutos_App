using CRAutos_App.ETL;
using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Controllers
{
    public class RecuperarContrasennaController : Controller
    {
        [HttpGet]
        // GET: RecuperarContrasenna
        public ActionResult Recuperar()
        {
            RecuperarContrasenna recuperar = new RecuperarContrasenna();
            return View(recuperar);
        }

        [HttpPost]
        public ActionResult Recuperar(ETL.RecuperarContrasenna recuperar)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(recuperar);
                }
                else
                {
                    RecuperarContrasennaModel generarRecuperacion = new RecuperarContrasennaModel();
                    var respuesta = generarRecuperacion.Recuperar(recuperar);
                    if (respuesta != null)
                    {
                        recuperar.SuccesfulMessage = "Correo enviado, verifique para el cambio de su contraseña";
                        return View(recuperar);
                    }
                    else
                    {
                        recuperar.ErrorMessage = "Ocurrio un error";
                        return View(recuperar);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult CambiarContrasenna(string token)
        {
            CambiarContrasenna model = new CambiarContrasenna();
            model.token = token;
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return View("ErrorTokenInvalido");
                }
                var oUser = contexto.TBUsuario.Where(d => d.TokenRecovery == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    return View("ErrorTokenInvalido");

                }
            }
            return View(model);
        }

        public ActionResult CambiarContrasenna(ETL.CambiarContrasenna cambio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cambio);
                }
                else
                {
                    RecuperarContrasennaModel cambiarContrasenna = new RecuperarContrasennaModel();
                    var respuesta = cambiarContrasenna.CambiarContrasena(cambio);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.Message = "Contraseña modificada con éxito";
            return RedirectToAction("IniciarSesion","IniciarSesion");
        }

    }
}
using CRAutos_App.ETL;
using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipoVendedorModel = CRAutos_App.ETL.TipoVendedorModel;

namespace CRAutos_App.Controllers
{
    public class RegistrarseController : Controller
    {
        [HttpGet]
        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Vendedor vendedor)
        {
            RegistrarVendedor registrarVendedor = new RegistrarVendedor();
            try
            {
                var resultado = registrarVendedor.RegistrarDatos(vendedor);
                if(resultado == "error")
                {
                    ViewBag.Error = "error no se puede registrar";
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }

        }
    }
}
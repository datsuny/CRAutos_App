using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRAutos_App.Models;

namespace CRAutos_App.Controllers
{
    public class VerCarrosController : Controller
    {
        // GET: VerCarros
        public ActionResult VerCarros()
        {
            //TBPublicaciones publicacionesTB = new TBPublicaciones();
            ConsultaVehiculo consulta = new ConsultaVehiculo();

            var publicacion = consulta.ListarVehiculos();

            if (publicacion.Count > 0)
            {
                return View(publicacion);
            }
            else
            {
                return View(publicacion);
            }
        }
    }
}
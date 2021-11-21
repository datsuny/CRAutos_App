using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRAutos_App.Models;

namespace CRAutos_App.Controllers
{
    public class PublicacionesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            //TBPublicaciones publicacionesTB = new TBPublicaciones();
            ConsultaVehiculo consulta = new ConsultaVehiculo();

            var publicacion = consulta.ListarVehiculos();

            if(publicacion.Count > 0)
            {
                return Json(publicacion, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(publicacion, JsonRequestBehavior.DenyGet);
            }

            //return View();
        }
    }
}
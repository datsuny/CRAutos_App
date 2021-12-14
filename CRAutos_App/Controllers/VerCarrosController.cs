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
      

        [HttpGet]
        public ActionResult filtroDetalles()
        {

            try
            {
                FiltroVehiculos filtroM = new FiltroVehiculos();

                var consulta = filtroM.ObtenerCondicion();

                List<SelectListItem> ListaCondicion = new List<SelectListItem>();
                foreach (var item in consulta)
                {
                    ListaCondicion.Add(new SelectListItem
                    {
                        Value = item.IDCondicion.ToString(),
                        Text = item.CondicionVehiculo
                    });
                }
                ViewBag.ListaCondicion = ListaCondicion;

                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }

        }

        [HttpGet]
        public ActionResult mostrarResultadoFiltro(CRAutos_App.ETL.Filtrar datos)
        {

            try
            {
                FiltroVehiculos filtroM = new FiltroVehiculos();


                var listaDatos = filtroM.obtenerPublicaciones(datos);



                if (listaDatos.Count > 0)
                {
                    return View(listaDatos);
                }
                else
                {
                    return View(listaDatos);
                }

            }
            catch (Exception)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }

        }

    }
}
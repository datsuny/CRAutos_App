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
        //[HttpGet]
        //public ActionResult mostrarDetalles(CRAutos_App.Models.TBPublicaciones id)
        //{
            
        //    modeloPublicaciones mPublicaciones = new modeloPublicaciones();
        //    var respuesta = mPublicaciones.mostrarTodaPublicacion();

        //    List<SelectListItem> combo = new List<SelectListItem>();

        //    foreach(var item in respuesta)
        //    {
        //        combo.Add(new SelectListItem
        //        {
        //            Value = item.IDPublicacion.ToString(),
        //            Text = item.Descripcion
        //        });
        //    }

        //    ViewBag.Data = combo;

        //    var publicacionFiltrada = respuesta.Where(x => x.IDPublicacion == id.IDPublicacion).ToList();
            
        //    return View("mostrarDetalles", publicacionFiltrada);
        //}

        [HttpGet]
        public ActionResult filtroDetalles()
        {

            try
            {
                FiltroVehiculos filtroM = new FiltroVehiculos();

                var consulta = filtroM.obtenerStatus();

                List<SelectListItem> listaStatus = new List<SelectListItem>();
                foreach (var item in consulta)
                {
                    listaStatus.Add(new SelectListItem
                    {
                        Value = item.IDEstatus.ToString(),
                        Text = item.Estatus
                    });
                }
                ViewBag.listaStatus = listaStatus;

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


                datos.listaDatos = filtroM.obtenerPublicaciones(datos);



                if (datos.listaDatos.Count > 0)
                {
                    return View(datos);
                }
                else
                {
                    return View(datos);
                }

            }
            catch (Exception)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }

        }

    }
}
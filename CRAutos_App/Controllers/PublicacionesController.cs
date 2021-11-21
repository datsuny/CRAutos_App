using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Controllers
{
    public class PublicacionesController : Controller
    {
        public ActionResult ProcesoConsulta(Vendedor vendedor)
        {
            /*logica*/
            modeloPublicaciones modelo = new modeloPublicaciones();

            TBUsuario usuario = (TBUsuario)Session["vendedorLogeado"];

            vendedor.IDVendedor = usuario.IDVendedor;

            var publicacion = modelo.ListaPublicaciones(vendedor);

            if (publicacion.Count > 0)
            {
                return View(publicacion);
            }
            else
            {
                return View(publicacion);
            }
        }

        public ActionResult ProcesoVehiculo()
        {
            return View();
        }

        public ActionResult ProcesoPublicacion()
        {
            return View();
        }
    }
}
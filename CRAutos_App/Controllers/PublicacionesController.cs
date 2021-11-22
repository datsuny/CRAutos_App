using CRAutos_App.ETL;
using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Controllers
{
    public class PublicacionesController : Controller
    {
        [HttpGet]
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

        [HttpGet]
        public ActionResult ProcesoVehiculo()
        {
            DatosVehiculo vehiculo = new DatosVehiculo();
            return View(vehiculo);
        }


        [HttpPost]
        public ActionResult ProcesoVehiculo(DatosVehiculo vehiculo)
        {
            AgregarVehiculoModel agregar = new AgregarVehiculoModel();

            var respuesta = agregar.AgregarVehiculo(vehiculo);

            if (respuesta != null)
            {
                using (CrAutosDBEntities context = new CrAutosDBEntities())
                {
                    var buscarVehiculo = (from x in context.TBVehiculo
                                          where x.Matricula == vehiculo.Matricula
                                          select x).FirstOrDefault();

                    string filename = Path.GetFileNameWithoutExtension(vehiculo.ImageFile.FileName);
                    string extension = Path.GetExtension(vehiculo.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    vehiculo.Imagen = "../Imagen/" + filename;
                    filename = Path.Combine(Server.MapPath("../Imagen/"), filename);
                    vehiculo.ImageFile.SaveAs(filename);

                    TBFotos fotoVehiculo = new TBFotos();
                    fotoVehiculo.Imagen = filename;
                    fotoVehiculo.IDVehiculo = buscarVehiculo.IDVehiculo;


                    context.TBFotos.Add(fotoVehiculo);
                    context.SaveChanges();
                   
                }
            }

            AgregarPublicacionModel agregarPublicacion = new AgregarPublicacionModel();

             var respuesta2 = agregarPublicacion.AgregarPublicacion();



            return RedirectToAction("ProcesoPublicacion");

        }

        //[HttpGet]
        //public ActionResult ProcesoPublicacion()
        //{
        //   TBPublicaciones publicaciones = new TBPublicaciones();
        //    return View(publicaciones);
        //}

        //public ActionResult ProcesoPublicacion(TBPublicaciones publicacio)
        //{
        //    AgregarPublicacionModel agregar = new AgregarPublicacionModel();

        //    var respuesta = agregar.AgregarPublicacion();
        //    return View();
        //}
    }
}
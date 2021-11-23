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
        /*---------------------------------------------------------------------------*/
        //SE CONSULTA LAS PUBLICACIONES QUE CONTIENE EL USUARIOS LOGUEADO
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

        /*---------------------------------------------------------------------------*/

        //SE CONSULTA LAS MARCAS PARA INGRESAR AL VISTA Y VER EL LOS DATOS A LLENAR
        private IEnumerable<SelectListItem> Marcas;
        private IEnumerable<SelectListItem> Condicion;
        private IEnumerable<SelectListItem> Estatus;
        [HttpGet]
        public ActionResult ProcesoVehiculo()
        {
            llenarMarca();
            llenarCondicion();
            llenarEstus();
            ListasdedatosPublicacion modelo = new ListasdedatosPublicacion();
            DatosVehiculo datos = new DatosVehiculo();
            datos.listaMarcas = Marcas;
            datos.listaCondicion = Condicion;
            datos.listaEstatus = Estatus;

            return View(datos);
            
        }
        private void llenarMarca()
        {
            Marcas = new ListasdedatosPublicacion().consultaMarca().ToList().Select(m => 
            new SelectListItem { Value = m.IDMarca.ToString(), Text = m.NombreMarca });
        }

        /*---------------------------------------------------------------------------*/

        //Se registra el vehiculo
        [HttpPost]
        public ActionResult ProcesoVehiculo(CRAutos_App.ETL.DatosVehiculo datos)
        {
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                var consulta = (from x in context.TBVehiculo
                                where x.Matricula == datos.Matricula
                                select x).FirstOrDefault();

                if (consulta == null)
                {
                    TBVehiculo nuevoVehiculo = new TBVehiculo();
                    nuevoVehiculo.Matricula = datos.Matricula;
                    nuevoVehiculo.Kilometraje = datos.Kilometraje;
                    nuevoVehiculo.Cilindraje = datos.Cilindraje;
                    nuevoVehiculo.Transmision = datos.Transmision;
                    nuevoVehiculo.Color = datos.Color;
                    nuevoVehiculo.NumeroPuertas = datos.NumeroPuertas;
                    nuevoVehiculo.Año = datos.Año;
                    nuevoVehiculo.Combustible = datos.Combustible;
                    nuevoVehiculo.IDMarca = datos.IDMarca;
                    nuevoVehiculo.IDModelo = null;

                    context.TBVehiculo.Add(nuevoVehiculo);
                    context.SaveChanges();

                    agregarFotosVehiculo(datos);
                    procesoPublicacion(datos);

                }
            }
            return RedirectToAction("ProcesoConsulta", "Publicaciones");
        }

        /*---------------------------------------------------------------------------*/
        public void agregarFotosVehiculo(DatosVehiculo datos)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var carroIngresado = (from x in contexto.TBVehiculo
                                 where x.Matricula == datos.Matricula
                                 select x).FirstOrDefault();

                string filename = Path.GetFileNameWithoutExtension(datos.ImageFile.FileName);
                string extension = Path.GetExtension(datos.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                datos.Imagen = "../Imagen/" + filename;
                filename = Path.Combine(Server.MapPath("../Imagen/"), filename);
                datos.ImageFile.SaveAs(filename);

                TBFotos imagen = new TBFotos();
                imagen.IDVehiculo = carroIngresado.IDVehiculo;
                imagen.Imagen = datos.Imagen;

                contexto.TBFotos.Add(imagen);
                contexto.SaveChanges();
            }
        }

        /*---------------------------------------------------------------------------*/
        public void procesoPublicacion(DatosVehiculo datos)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var carroIngresado = (from x in contexto.TBVehiculo
                                      where x.Matricula == datos.Matricula
                                      select x).FirstOrDefault();

                TBPublicaciones publicacion = new TBPublicaciones();
                publicacion.TituloPublicacion = datos.TituloPublicacion;
                publicacion.Descripcion = datos.Descripcion;
                publicacion.Precio = datos.Precio;
                publicacion.Ubicacion = datos.Ubicacion;
                publicacion.IDVehiculo = carroIngresado.IDVehiculo;
                publicacion.Fecha = DateTime.Now;
                publicacion.IDEstatus = datos.IDEstatus;
                publicacion.IDCondicion = datos.IDCondicion;

                TBUsuario usuario = (TBUsuario)Session["vendedorLogeado"];
                publicacion.IDVendedor = usuario.IDVendedor;

                string filename = Path.GetFileNameWithoutExtension(datos.ImagePortada.FileName);
                string extension = Path.GetExtension(datos.ImagePortada.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                datos.Portada = "../Imagen/" + filename;
                filename = Path.Combine(Server.MapPath("../Imagen/"), filename);
                datos.ImagePortada.SaveAs(filename);

                publicacion.Imagen = datos.Portada;

                contexto.TBPublicaciones.Add(publicacion);
                contexto.SaveChanges();

            }
        }

        /*---------------------------------------------------------------------------*/
        private void llenarCondicion()
        {
            Condicion = new ListasdedatosPublicacion().consultaCondicion().ToList().Select(m =>
            new SelectListItem { Value = m.IDCondicion.ToString(), Text = m.CondicionVehiculo });
        }
        private void llenarEstus()
        {
            Estatus = new ListasdedatosPublicacion().consultaEstatus().ToList().Select(m =>
            new SelectListItem { Value = m.IDEstatus.ToString(), Text = m.Estatus });
        }
    }
}
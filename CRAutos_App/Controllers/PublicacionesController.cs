using CRAutos_App.ETL;
using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace CRAutos_App.Controllers
{
    public class PublicacionesController : Controller
    {
        /*---------------------------------------------------------------------------*/
        //SE CONSULTA LAS PUBLICACIONES QUE CONTIENE EL USUARIOS LOGUEADO
        [HttpGet]
        public ActionResult PublicacionesVehiculos(Vendedor vendedor)
        {
            try
            {
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
            catch (Exception)
            {

                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        /*---------------------------------------------------------------------------*/
        //SE CONSULTA LAS MARCAS PARA INGRESAR AL VISTA Y VER EL LOS DATOS A LLENAR
        private IEnumerable<SelectListItem> Marcas;
        private IEnumerable<SelectListItem> Modelos;
        [HttpGet]
        public ActionResult RegistroVehiculo()
        {
            try
            {
                RegistroVehiculo modelo = new RegistroVehiculo();
                var consulta = modelo.obtenerMarcas();

                List<SelectListItem> listaMarcas = new List<SelectListItem>();
                foreach (var item in consulta)
                {
                    listaMarcas.Add(new SelectListItem
                    {
                        Value=item.IDMarca.ToString(),
                        Text=item.NombreMarca
                    });
                }
                ViewBag.listaMarca = listaMarcas;
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        //Se registra el vehiculo
        [HttpPost]
       public ActionResult RegistroVehiculo(CRAutos_App.ETL.DatosVehiculo datos)
        {
            try
            {
                RegistroVehiculo registro = new RegistroVehiculo();
                registro.RegistrarVehiculo(datos);

                buscarVehiculo vehiculo = new buscarVehiculo();
                var respuesta = vehiculo.validarVehiculo(datos);

                if (respuesta == null)
                {
                    ViewBag.Error = "No se encuentra el vehiculo registrado";
                }
                else
                {
                    Session["vehiculoRegistrado"] = respuesta;
                }

                agregarFotosVehiculo(datos);

                return RedirectToAction("RegistroDetallesVehiculo", "Publicaciones");
            }
            catch (Exception)
            {

                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        //Se llena la lista de marcas que se necesita
        private void llenarMarca()
        {
            Marcas = new ListasdedatosPublicacion().consultaMarca().ToList().Select(m =>
            new SelectListItem { Value = m.IDMarca.ToString(), Text = m.NombreMarca });
        }

        // se hace registro de las fotos del vehiculo
        public void agregarFotosVehiculo(DatosVehiculo datos)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                TBVehiculo vehiculo = (TBVehiculo)Session["vehiculoRegistrado"];
                datos.IDVehiculo = vehiculo.IDVehiculo;

                string filename = Path.GetFileNameWithoutExtension(datos.ImageFile.FileName);
                string extension = Path.GetExtension(datos.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                datos.Imagen = "../Imagen/" + filename;
                filename = Path.Combine(Server.MapPath("../Imagen/"), filename);
                datos.ImageFile.SaveAs(filename);

                TBFotos imagen = new TBFotos();
                imagen.IDVehiculo = datos.IDVehiculo;
                imagen.Imagen = datos.Imagen;

                contexto.TBFotos.Add(imagen);
                contexto.SaveChanges();
            }
        }

        /*---------------------------------------------------------------------------*/
        // se llama a la vista de los detalles para hacer el registro 
        [HttpGet]
        public ActionResult RegistroDetallesVehiculo()
        {
            try
            {
                datosDetalle datos = new datosDetalle();
                registroDetallesVehiculo modelo = new registroDetallesVehiculo();
                var consulta = modelo.consultaExtras();

                datos.listaExtras = consulta;

                return View(datos);
            }
            catch (Exception)
            {

                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        //se registra los detalles del vehiculo
        [HttpPost]
        public ActionResult RegistroDetallesVehiculo(CRAutos_App.ETL.datosDetalle datos)
        {
            try
            {
                TBVehiculo vehiculo = (TBVehiculo)Session["vehiculoRegistrado"];
                datos.IDVehiculo = vehiculo.IDVehiculo;

                registroDetallesVehiculo modelo = new registroDetallesVehiculo();
                var respuesta = modelo.registroDetalles(datos);
                foreach (var item in datos.listaExtras)
                {
                    if (item.isCheck)
                    {
                        using (CrAutosDBEntities contexto=new CrAutosDBEntities())
                        {
                            TBExtrasVehiculo extras = new TBExtrasVehiculo();
                            extras.IDExtra = item.IDExtra;
                            extras.IDVehiculo = datos.IDVehiculo;

                            contexto.TBExtrasVehiculo.Add(extras);
                            contexto.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("RegistroPublicacion", "Publicaciones");
            }
            catch (Exception)
            {

                 return View("~/Views/Shared/ErrorPagina.cshtml");
            }
           
        }
        /*---------------------------------------------------------------------------*/
       //se llama a la vista de publicaciones para hacer el resgistro 

        private IEnumerable<SelectListItem> Condicion;
        private IEnumerable<SelectListItem> Estatus;
        [HttpGet]
        public ActionResult RegistroPublicacion()
        {
            try
            {
                llenarCondicion();
                llenarEstus();
                ListasdedatosPublicacion modelo = new ListasdedatosPublicacion();
                datosPublicacion datos = new datosPublicacion();
                datos.listaCondicion = Condicion;
                datos.listaEstatus = Estatus;
                return View(datos);
            }
            catch (Exception)
            {

                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        //se registra la publicacion del vehiculo
        [HttpPost]
        public ActionResult RegistroPublicacion(CRAutos_App.ETL.datosPublicacion datos)
        {
            try
            {
                using (CrAutosDBEntities contexto = new CrAutosDBEntities())
                {
                    TBVehiculo vehiculo = (TBVehiculo)Session["vehiculoRegistrado"];
                    datos.IDVehiculo = vehiculo.IDVehiculo;

                    TBPublicaciones publicacion = new TBPublicaciones();
                    publicacion.TituloPublicacion = datos.TituloPublicacion;
                    publicacion.Descripcion = datos.Descripcion;
                    publicacion.Precio = datos.Precio;
                    publicacion.Ubicacion = datos.Ubicacion;
                    publicacion.IDVehiculo = datos.IDVehiculo;
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

                return RedirectToAction("PublicacionesVehiculos", "Publicaciones");
            }
            catch (Exception)
            {

                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        //se llena lista de condicion para saber que condiciones presenta los vehiculos 
        private void llenarCondicion()
         {
             Condicion = new ListasdedatosPublicacion().consultaCondicion().ToList().Select(m =>
             new SelectListItem { Value = m.IDCondicion.ToString(), Text = m.CondicionVehiculo });
         }

        //se llena la lista de estatus para saber el estado que presenta la publicacion
        private void llenarEstus()
         {
             Estatus = new ListasdedatosPublicacion().consultaEstatus().ToList().Select(m =>
             new SelectListItem { Value = m.IDEstatus.ToString(), Text = m.Estatus });
         }

        /*---------------------------------------------------------------------------*/
    }
}
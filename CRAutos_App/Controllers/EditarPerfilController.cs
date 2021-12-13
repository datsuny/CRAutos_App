using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Controllers
{
    public class EditarPerfilController : Controller
    {

        [HttpGet]
        public ActionResult EditarPerfil(TBVendedor vendedor)
        {
            try
            {
                EditarPerfilModel editar = new EditarPerfilModel();

                TBUsuario usuario = (TBUsuario)Session["vendedorLogeado"];

                vendedor.IDVendedor = usuario.IDVendedor;

                var respuesta = editar.DatosVendedor(vendedor);

                return View(respuesta);
            }catch (Exception)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }

        [HttpPost]
        public ActionResult ActualizarPerfil(TBVendedor vendedor)
        {
            try
            {
                EditarPerfilModel editar = new EditarPerfilModel();

                TBUsuario usuario = (TBUsuario)Session["vendedorLogeado"];

                vendedor.IDVendedor = usuario.IDVendedor;
                var respuesta = editar.EditarDatos(vendedor);

                if (respuesta != null)
                {
                    ViewBag.Actualizado = "Perfil actualizado con exito";

                    vendedor.IDVendedor = usuario.IDVendedor;

                    var respuesta2 = editar.DatosVendedor(vendedor);

                    return View("EditarPerfil", respuesta2);
                }
                else
                {
                    ViewBag.Actualizado = "Error en la actualización";

                    vendedor.IDVendedor = usuario.IDVendedor;

                    var respuesta2 = editar.DatosVendedor(vendedor);
                    return View("EditarPerfil", respuesta2);
                }
            }catch (Exception)
            {
                return View("~/Views/Shared/ErrorPagina.cshtml");
            }
        }
    }
}
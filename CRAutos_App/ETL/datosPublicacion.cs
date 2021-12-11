using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.ETL
{
    public class datosPublicacion
    {
        public string TituloPublicacion { get; set; }
        public string Portada { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public long IDVendedor { get; set; }
        public long IDEstatus { get; set; }
        public long IDCondicion { get; set; }
        public long IDVehiculo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImagePortada { get; set; }
        public TBCondicionVehiculo condicion { get; set; }
        public IEnumerable<SelectListItem> listaCondicion { get; set; }
        public TBEstatusPublicacion estatus { get; set; }
        public IEnumerable<SelectListItem> listaEstatus { get; set; }

    }
}
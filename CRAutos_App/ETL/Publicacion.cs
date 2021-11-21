using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRAutos_App.Models;

namespace CRAutos_App.ETL
{
    public class Publicacion
    {
        public long IDPublicacion { get; set; }
        public string TituloPublicacion { get; set; }
        public long IDVehiculo { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public long IDVendedor { get; set; }
        public long IDEstatus { get; set; }
        public long IDCondicion { get; set; }

        public virtual TBCondicionVehiculo TBCondicionVehiculo { get; set; }
        public virtual TBEstatusPublicacion TBEstatusPublicacion { get; set; }
        public virtual TBVehiculo TBVehiculo { get; set; }
        public virtual TBVendedor TBVendedor { get; set; }
    }
}
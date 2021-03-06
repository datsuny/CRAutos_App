//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRAutos_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBPublicaciones
    {
        public long IDPublicacion { get; set; }
        public string TituloPublicacion { get; set; }
        public long IDVehiculo { get; set; }
        public string Imagen { get; set; }
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

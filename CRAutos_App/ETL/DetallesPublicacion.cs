using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class DetallesPublicacion
    {
        /*TBPublicacion*/
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

        /*//TBPublicacion*/

        /*TBVehiculo*/
        public string Matricula { get; set; }
        public decimal Kilometraje { get; set; }
        public string Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Color { get; set; }
        public int NumeroPuertas { get; set; }
        public int Año { get; set; }
        public string Combustible { get; set; }

        /*//TBVehiculo*/

        /*TBVendedor*/
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        /*//TBVendedor*/

    }
}
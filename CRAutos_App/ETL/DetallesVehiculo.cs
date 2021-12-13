using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class DetallesVehiculo
    {
        public string Imagen { get; set; }
        public string TituloPublicacion { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public decimal Kilometraje { get; set; }
        public string Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Color { get; set; }
        public int NumeroPuertas { get; set; }
        public int Año { get; set; }
        public string Combustible { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
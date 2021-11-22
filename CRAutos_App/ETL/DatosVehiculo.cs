using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class DatosVehiculo
    {
        public long IDVehiculo { get; set; }
        public string Matricula { get; set; }
        public decimal Kilometraje { get; set; }
        public string Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Color { get; set; }
        public int NumeroPuertas { get; set; }
        public int Año { get; set; }
        public string Combustible { get; set; }
        public long IDMarca { get; set; }
        public string TipoModelo { get; set; }

        public string Imagen { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        public string TituloPublicacion { get; set; }
        public string Portada { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFilePortada { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public long IDVendedor { get; set; }
        public long IDEstatus { get; set; }
        public long IDCondicion { get; set; }


    }
}
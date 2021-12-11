using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class datosDetalle
    {
        public long IDVehiculo { get; set; }
        public decimal Kilometraje { get; set; }
        public string Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Color { get; set; }
        public int NumeroPuertas { get; set; }
        public int Año { get; set; }
        public string Combustible { get; set; }
        public long IDExtraVehiculo { get; set; }

        public long IDExtra { get; set; }
        public string NombreExtra { get; set; }
        public bool isCheck { get; set; }
        public List<datosDetalle> listaExtras { get; set; }
    }
}
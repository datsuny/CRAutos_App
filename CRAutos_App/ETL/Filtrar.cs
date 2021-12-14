using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRAutos_App.Models;

namespace CRAutos_App.ETL
{
    public class Filtrar
    {

        /**/

        public long IDPublicacion { get; set; }
        public string TituloPublicacion { get; set; }
        public long IDVehiculo { get; set; }
        public string Imagen { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public long IDVendedor { get; set; }

        /**/

        public string NombreMarca { get; set; }

        public long IDMarca { get; set; }


        public string Ubicacion { get; set; }

        public int IDCondicion { get; set; }

        public long IDEstatus { get; set; }

        public string Estatus { get; set; }

        public string CondicionVehiculo { get; set; }

        public IEnumerable<SelectListItem> listaEstatus { get; set; }

        public List<Filtrar> listaDatos { get; set; }


    }
}
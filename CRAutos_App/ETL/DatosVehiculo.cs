using CRAutos_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.ETL
{
    public class DatosVehiculo
    {
        /*Vehiculo*/
        public long IDVehiculo { get; set; }
        public string Matricula { get; set; }
        public decimal Kilometraje { get; set; }
        public string Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Color { get; set; }
        public int NumeroPuertas { get; set; }
        public int Año { get; set; }
        public string Combustible { get; set; }
        public long  IDMarca { get; set; }
        public string NombreMarca { get; set; }
        public string TipoModelo { get; set; }
        public TBMarca marca { get; set; }
        public IEnumerable<SelectListItem> listaMarcas { get; set; }

        public TBModelo modelo { get; set; }
        public IEnumerable<SelectListItem> listaModelos { get; set; }


        /*Foto*/
        public string Imagen { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        /*Publicacion*/
        public string TituloPublicacion { get; set; }
        public string Portada { get; set; }

        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public long IDVendedor { get; set; }
        public long IDEstatus { get; set; }
        public long IDCondicion { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImagePortada { get; set; }
        public TBCondicionVehiculo condicion { get; set; }
        public IEnumerable<SelectListItem> listaCondicion { get; set; }

        public TBEstatusPublicacion estatus { get; set; }
        public IEnumerable<SelectListItem> listaEstatus { get; set; }


    }
}
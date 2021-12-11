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
    public class DatosVehiculo
    {
        /*Vehiculo*/
        public long IDVehiculo { get; set; }

        public string Matricula { get; set; }
        public long  IDMarca { get; set; }
        public string NombreMarca { get; set; }
        public string TipoModelo { get; set; }


        /*Foto*/
        public string Imagen { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }



    }
}
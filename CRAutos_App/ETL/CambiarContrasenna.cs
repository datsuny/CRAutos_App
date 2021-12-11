using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class CambiarContrasenna
    {
        public string token { get; set; }
        [Required]
        public string Contrasenna { get; set; }

        [Compare("Contrasenna")]
        [Required]
        public string Contrasenna2 { get; set; }
    }
}
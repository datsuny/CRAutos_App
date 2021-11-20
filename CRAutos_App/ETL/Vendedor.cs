using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Models
{
    public class Vendedor
    {
        public long IDVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Empresa { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public long IDTipoVendedor { get; set; }
        public int Calificación { get; set; }

        public string NombreUsuario { get; set; }
        public string Contrasenna { get; set; }
    }

}
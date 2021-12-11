using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class RecuperarContrasenna
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccesfulMessage { get; set; }
    }
}
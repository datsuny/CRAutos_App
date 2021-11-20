using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.ETL
{
    public class TipoVendedor
    {
        public long IDTipoVendedor { get; set; }
        public string NombreTipo { get; set; }

        public bool IsChecked { get; set; }
    }

    public class TipoVendedorModel
    {
        public List<TipoVendedor> TipoVendedores { get; set; }
    }

}
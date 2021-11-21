using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class modeloPublicaciones
    {
        public List<TBPublicaciones> ListaPublicaciones(Vendedor vendedor)
        {

            using (var contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBPublicaciones
                        where x.IDVendedor== vendedor.IDVendedor
                        select x).ToList();
            }
        }
    }
}

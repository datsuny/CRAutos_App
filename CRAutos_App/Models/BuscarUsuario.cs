using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class BuscarUsuario
    {
        public TBUsuario ValidarUsuario(Vendedor vendedor)
        {
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                var buscarUsuario = (from x in context.TBUsuario
                                     where x.NombreUsuario == vendedor.NombreUsuario
                                     && x.Contrasenna == vendedor.Contrasenna
                                     select x).FirstOrDefault();
 
                if (buscarUsuario == null)
                {
                    return null;
                }
                else
                {
                    return buscarUsuario;
                }
            }
        }
    }
}
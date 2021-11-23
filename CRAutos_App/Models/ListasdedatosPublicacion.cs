using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Models
{
    public class ListasdedatosPublicacion
    {

        public List<TBMarca> consultaMarca()
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities() )
            {
                return (from x in contexto.TBMarca
                        select x).ToList();
            }
        }
        public List<TBCondicionVehiculo> consultaCondicion()
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBCondicionVehiculo  
                        select x).ToList();
            }
        }

        public List<TBEstatusPublicacion> consultaEstatus()
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBEstatusPublicacion
                        select x).ToList();
            }
        }
    }
}
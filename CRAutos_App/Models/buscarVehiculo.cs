using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class buscarVehiculo
    {
        public TBVehiculo validarVehiculo(DatosVehiculo vehiculo)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var buscarVehiculo = (from x in contexto.TBVehiculo
                                      where x.Matricula == vehiculo.Matricula
                                      select x).FirstOrDefault();
                if (buscarVehiculo == null)
                {
                    return null;
                }
                else
                {
                    return buscarVehiculo;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class ConsultaVehiculo
    {

        public List<TBPublicaciones> ListarVehiculos()
        {
            using (var contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBPublicaciones
                        select x).ToList();
            }
        }

    }
}
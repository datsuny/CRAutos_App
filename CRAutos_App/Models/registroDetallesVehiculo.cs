using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace CRAutos_App.Models
{
    public class registroDetallesVehiculo
    {
        public List<datosDetalle> consultaExtras()
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var consulta = (from x in contexto.TBExtra
                                select x).ToList();
                if (consulta.Count>0)
                {
                    List<datosDetalle> listaExtras = new List<datosDetalle>();
                    foreach (var item in consulta)
                    {
                        listaExtras.Add(new datosDetalle
                        {
                            IDExtra=item.IDExtra,
                            NombreExtra=item.NombreExtra,
                            isCheck=false
                        });
                    }    
                    return listaExtras;
                }
                else
                {
                    return new List<datosDetalle>();
                }
            }
        }

        public string registroDetalles(datosDetalle datos)
        {
            using (CrAutosDBEntities contexto= new CrAutosDBEntities())
            {
                var mensaje = "";

                TBDetalleVehiculo detalle = new TBDetalleVehiculo();
                detalle.Kilometraje = datos.Kilometraje;
                detalle.Cilindraje = datos.Cilindraje;
                detalle.Transmision = datos.Transmision;
                detalle.Color = datos.Color;
                detalle.NumeroPuertas = datos.NumeroPuertas;
                detalle.Año = datos.Año;
                detalle.Combustible = datos.Combustible;
                detalle.IDVehiculo = datos.IDVehiculo;

                contexto.TBDetalleVehiculo.Add(detalle);
                contexto.SaveChanges();

                return mensaje = "se registro";
            }
        }
    }
}
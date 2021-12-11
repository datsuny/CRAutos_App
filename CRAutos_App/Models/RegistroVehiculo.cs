using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class RegistroVehiculo
    {
        public List<DatosVehiculo> obtenerMarcas()
        {
            using (CrAutosDBEntities contexto= new CrAutosDBEntities())
            {
                var lista = (from x in contexto.TBMarca
                             select x).ToList();
                List<DatosVehiculo> listaMarcas = new List<DatosVehiculo>();
                if (lista.Count>0)
                {
                    foreach (var item in lista)
                    {
                        listaMarcas.Add(new DatosVehiculo
                        {
                            IDMarca=item.IDMarca,
                            NombreMarca=item.NombreMarca
                        });
                    }
                    return listaMarcas;
                }
                else
                {
                    return new List<DatosVehiculo>();
                }
            }
        }

        public void RegistrarVehiculo(DatosVehiculo datos)
        {
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                string mensaje = " ";
                var consulta = (from x in context.TBVehiculo
                                where x.Matricula == datos.Matricula
                                select x).FirstOrDefault();

                if (consulta == null)
                {
                    TBVehiculo nuevoVehiculo = new TBVehiculo();
                    nuevoVehiculo.Matricula = datos.Matricula;
                    nuevoVehiculo.IDMarca = datos.IDMarca;
                    nuevoVehiculo.TipoModelo = datos.TipoModelo;

                    context.TBVehiculo.Add(nuevoVehiculo);
                    context.SaveChanges();
                    mensaje = "se agrego el vehiculo correctamente"; 
                }
                else
                {
                    mensaje = "no se pudo agregar el vehiculo";
                }
            }
        }
    }
}
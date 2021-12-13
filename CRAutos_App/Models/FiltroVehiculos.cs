using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRAutos_App.ETL;

namespace CRAutos_App.Models
{
    public class FiltroVehiculos
    {

        public List<Filtrar> obtenerStatus()
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var lista = (from x in contexto.TBEstatusPublicacion
                             select x).ToList();
                List<Filtrar> listaStatus = new List<Filtrar>();
                if (lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        listaStatus.Add(new Filtrar
                        {
                            IDEstatus = item.IDEstatus,
                            Estatus = item.Estatus
                        });
                    }
                    return listaStatus;
                }
                else
                {
                    return new List<Filtrar>();
                }
            }
        }

        public List<Filtrar> obtenerPublicaciones(Filtrar datos)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var consulta = (from x in contexto.TBPublicaciones
                                where x.IDEstatus == datos.IDEstatus
                                select x).ToList();
                if (consulta.Count > 0)
                {
                    List<Filtrar> listaStatus = new List<Filtrar>();
                    foreach (var item in consulta)
                    {
                        listaStatus.Add(new Filtrar
                        {
                            IDPublicacion = item.IDPublicacion,
                            TituloPublicacion = item.TituloPublicacion,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Ubicacion = item.Ubicacion,
                            Fecha = item.Fecha,
                            Estatus = consultaStatus(item.IDEstatus),
                            CondicionVehiculo = consultaCondicion(item.IDCondicion),
                            Imagen = item.Imagen
                        });
                    }
                    return listaStatus;
                }
                else
                {
                    return new List<Filtrar>();
                }
            }
        }

        //public List<Filtrar> obtenerPublicacionesMarca(Filtrar datos)
        //{
        //    using (CrAutosDBEntities contexto = new CrAutosDBEntities())
        //    {
        //        var consulta = (from x in contexto.TB)
        //    }
        //}

        public string consultaStatus(long id)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var nombre = (from x in contexto.TBEstatusPublicacion
                                where x.IDEstatus == id
                                select x.Estatus).FirstOrDefault();
                return nombre;

            }
        }

        public string consultaCondicion(long id)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var nombre = (from x in contexto.TBCondicionVehiculo
                              where x.IDCondicion == id
                              select x.CondicionVehiculo).FirstOrDefault();
                return nombre;

            }
        }

    }
}
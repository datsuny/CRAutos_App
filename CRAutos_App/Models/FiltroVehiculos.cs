using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRAutos_App.ETL;

namespace CRAutos_App.Models
{
    public class FiltroVehiculos
    {

        public List<Filtrar> ObtenerCondicion()
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var lista = (from x in contexto.TBCondicionVehiculo
                             select x).ToList();
                List<Filtrar> listaCondicion = new List<Filtrar>();
                if (lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        listaCondicion.Add(new Filtrar
                        {
                            IDCondicion = (int)item.IDCondicion,
                            CondicionVehiculo = item.CondicionVehiculo
                        });
                    }
                    return listaCondicion;
                }
                else
                {
                    return new List<Filtrar>();
                }
            }
        }

        public List<DetallesVehiculo> obtenerPublicaciones(Filtrar datos)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var consulta = contexto.filtroPublicaciones(datos.IDCondicion);
                if (consulta!=null)
                {
                    List<DetallesVehiculo> ListaFiltrada = new List<DetallesVehiculo>();


                    foreach (var item in consulta)
                    {

                        ListaFiltrada.Add(new DetallesVehiculo
                        {
                            TituloPublicacion = item.TituloPublicacion,
                            Descripcion = item.Descripcion,
                            Fecha = item.Fecha,
                            Ubicacion = item.Ubicacion,
                            Kilometraje = item.Kilometraje,
                            Cilindraje = item.Cilindraje,
                            Transmision = item.Transmision,
                            Color = item.Color,
                            NumeroPuertas = item.NumeroPuertas,
                            Año = item.Año,
                            Combustible = item.Combustible,
                            Nombre = item.Nombre,
                            Apellido1 = item.Apellido1,
                            Apellido2 = item.Apellido2,
                            Telefono = item.Telefono,
                            Correo = item.Correo,
                            Imagen = item.Imagen,
                            Precio = item.Precio
                        });

                    }
                    return ListaFiltrada;
                }
                else
                {
                    return new List<DetallesVehiculo>();
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
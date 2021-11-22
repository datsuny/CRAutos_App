using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class AgregarPublicacionModel
    {
        public string AgregarPublicacion(DatosVehiculo publicacion) 
        {
            var respuestaRegistro = "";
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                var bVehiculo = (from x in context.TBVehiculo
                                       where x.Matricula == publicacion.Matricula
                                       select x).FirstOrDefault();

                if (bVehiculo == null)
                {
                    TBPublicaciones nuevapublicacion = new TBPublicaciones();



                    TBVehiculo nuevoVehiculo = new TBVehiculo();


                    nuevoVehiculo.Matricula = vehiculo.Matricula;
                    nuevoVehiculo.Kilometraje = vehiculo.Kilometraje;
                    nuevoVehiculo.Cilindraje = vehiculo.Cilindraje;
                    nuevoVehiculo.Transmision = vehiculo.Transmision;
                    nuevoVehiculo.Color = vehiculo.Color;
                    nuevoVehiculo.NumeroPuertas = vehiculo.NumeroPuertas;
                    nuevoVehiculo.Año = vehiculo.Año;
                    nuevoVehiculo.IDMarca = null;
                    nuevoVehiculo.TipoModelo = null;




                    context.TBVehiculo.Add(nuevoVehiculo);
                    context.SaveChanges();




                    respuestaRegistro = "Registro exitoso";
                }
                else
                {
                    respuestaRegistro = "error";
                }

                return respuestaRegistro;
            }


            return null;

        }
    }
}
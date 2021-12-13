using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class ConsultaVehiculo
    {

        public List<DetallesVehiculo> ListarVehiculos()
        {
            using (var contexto = new CrAutosDBEntities())
            {
                var publicacion = contexto.mostrarPublicacion();


                List<DetallesVehiculo> Lista = new List<DetallesVehiculo>();


                foreach (var item in publicacion)
                {

                    Lista.Add(new DetallesVehiculo
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
                return Lista;
            }

        }
    }
}
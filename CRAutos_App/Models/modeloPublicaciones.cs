using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRAutos_App.ETL;

namespace CRAutos_App.Models
{
    public class modeloPublicaciones
    {
        public List<TBPublicaciones> ListaPublicaciones(Vendedor vendedor)
        {

            using (var contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBPublicaciones
                        where x.IDVendedor == vendedor.IDVendedor
                        select x).ToList();
            }
        }

        public List<DetallesPublicacion> mostrarDetalles(int IDPublicacion)
        {
            List<DetallesPublicacion> modelo =new List<DetallesPublicacion>();
            using (var contexto = new CrAutosDBEntities())
            {
                
                var respuesta = contexto.mostrarPublicacion(IDPublicacion).ToList();

                foreach (var item in respuesta)
                {
                    modelo.Add(new DetallesPublicacion
                    {
                        TituloPublicacion = item.TituloPublicacion,
                        //Imagen = item.imagen,
                        Fecha = item.Fecha,
                        Precio = item.Precio,
                        Descripcion = item.Descripcion,
                        Ubicacion = item.Ubicacion,
                        Matricula = item.Matricula,
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
                        Correo = item.Correo
                    });
                   
                }

 
            }
            return modelo;
        }

        public List<TBPublicaciones> mostrarTodaPublicacion()
        {

            using (var contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBPublicaciones
                        select x).ToList();
            }
        }
    }
}

using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class AgregarVehiculoModel
    {
        public string AgregarVehiculo(DatosVehiculo vehiculo) 
        {
            var respuestaRegistro = "";
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                var usuarioVendedor = (from x in context.TBVehiculo
                                       where x.Matricula == vehiculo.Matricula
                                       select x).FirstOrDefault();

                if (usuarioVendedor == null)
                {
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
           
        }

        //public void registrarFoto(DatosVehiculo vehiculo)
        //{
        //    using (CrAutosDBEntities context = new CrAutosDBEntities())
        //    {
        //        var buscarVehiculo = (from x in context.TBVehiculo
        //                              where x.Matricula == vehiculo.Matricula
        //                              select x).FirstOrDefault();

        //        string filename = Path.GetFileNameWithoutExtension(vehiculo.ImageFile.FileName);
        //        string extension = Path.GetExtension(vehiculo.ImageFile.FileName);
        //        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
        //        vehiculo.Imagen = "../Imagen/" + filename;
        //        filename = Path.Combine(HttpServerUtility.MapPath("../Imagen/"), filename);
        //        vehiculo.ImageFile.SaveAs(filename);




        //        TBFotos fotoVehiculo = new TBFotos();
        //        fotoVehiculo.Imagen = filename;
        //        fotoVehiculo.IDVehiculo = buscarVehiculo.IDVehiculo;
             

        //        context.TBFotos.Add(fotoVehiculo);
        //        context.SaveChanges();

        //    }
        //}


    }
}
using CRAutos_App.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class RegistrarVendedor
    {
        public string RegistrarDatos(Vendedor vendedor)
        {
            var respuestaRegistro = "";
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                var usuarioVendedor = (from x in context.TBVendedor
                                       where x.Correo == vendedor.Correo
                                       select x).FirstOrDefault();

                if (usuarioVendedor == null)
                {
                    TBVendedor nuevoVendedor = new TBVendedor();

                    nuevoVendedor.Nombre = vendedor.Nombre;
                    nuevoVendedor.Apellido1 = vendedor.Apellido1;
                    nuevoVendedor.Apellido2 = vendedor.Apellido2;
                    nuevoVendedor.Telefono = vendedor.Telefono;
                    nuevoVendedor.Correo = vendedor.Correo;
                    nuevoVendedor.IDTipoVendedor = null;
                    nuevoVendedor.Empresa = null;
                    nuevoVendedor.Calificación = null;


                    context.TBVendedor.Add(nuevoVendedor);
                    context.SaveChanges();


                    registrarUsuario(vendedor);

                    respuestaRegistro = "Registro exitoso";
                }
                else
                {
                    respuestaRegistro = "error";
                }

                return respuestaRegistro;
            }

        }

  

        private void registrarUsuario(Vendedor vendedor)
        {
            using (CrAutosDBEntities context = new CrAutosDBEntities())
            {
                var buscarVendedor = (from x in context.TBVendedor
                                     where x.Correo == vendedor.Correo
                                     select x).FirstOrDefault();



                TBUsuario usuario = new TBUsuario();
                usuario.NombreUsuario = vendedor.NombreUsuario;
                usuario.Contrasenna = vendedor.Contrasenna;
                usuario.IDVendedor = buscarVendedor.IDVendedor;

                context.TBUsuario.Add(usuario);
                context.SaveChanges();

            }
        }


    }
}


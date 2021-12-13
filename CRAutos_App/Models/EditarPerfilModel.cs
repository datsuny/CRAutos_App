using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRAutos_App.Models
{
    public class EditarPerfilModel
    {
        public List<TBVendedor> DatosVendedor(TBVendedor vendedor)
        {

            using (var contexto = new CrAutosDBEntities())
            {
                return (from x in contexto.TBVendedor
                        where x.IDVendedor == vendedor.IDVendedor
                        select x).ToList();

            }
        }

        public string EditarDatos(TBVendedor vendedor)
        {
            var respuesta = "";

            using (var contexto = new CrAutosDBEntities())
            {
                var vendedorSeleccionado = (from x in contexto.TBVendedor
                                            where x.IDVendedor == vendedor.IDVendedor
                                            select x).FirstOrDefault();

                if (vendedorSeleccionado != null)
                {
                    vendedorSeleccionado.Correo = vendedor.Correo;
                    vendedorSeleccionado.Telefono = vendedor.Telefono;
                    contexto.SaveChanges();
                    return respuesta = "Exito";
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CRAutos_App.Models
{
    public class RecuperarContrasennaModel
    {
        public string Recuperar(ETL.RecuperarContrasenna recuperar)
        {
            var respuesta = "";
            string token = GetSha256(Guid.NewGuid().ToString());

            using (CrAutosDBEntities contexto = new Models.CrAutosDBEntities())
            {
                var Vendedor = contexto.TBVendedor.Where(d => d.Correo == recuperar.Email).FirstOrDefault();
                if (Vendedor != null)
                {
                    var VendedorSeleccionado = (from x in contexto.TBUsuario
                                                where x.IDVendedor == Vendedor.IDVendedor
                                                select x).FirstOrDefault();

                    VendedorSeleccionado.TokenRecovery = token;
                    contexto.SaveChanges();

                    //Enviar correo
                    SendEmail(Vendedor.Correo, token);

                    respuesta = "exitosa";
                }
                else
                {
                    respuesta = null;
                }

                return respuesta;
            }

        }

        public string CambiarContrasena(ETL.CambiarContrasenna cambio)
        {
            using (CrAutosDBEntities contexto = new CrAutosDBEntities())
            {
                var oUser = contexto.TBUsuario.Where(d => d.TokenRecovery == cambio.token).FirstOrDefault();

                if (oUser != null)
                {
                    oUser.Contrasenna = cambio.Contrasenna;
                    oUser.TokenRecovery = null;
                    contexto.SaveChanges();

                    return "exito";
                }
                else
                {
                    return null;
                }
            }
        }



        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        string urlDomain = "https://localhost:44305/";
        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "proyectoProgra123456@gmail.com";
            string Contraseña = "proyectoprogra";
            string url = urlDomain + "RecuperarContra/CambiarContrasenna/?token=" + token;
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperación de contraseña",
                "<p>Correo para recuperación de contraseña</p><br>" +
                "<a href='" + url + "'>Click para recuperar</a>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();
        }
    }
}
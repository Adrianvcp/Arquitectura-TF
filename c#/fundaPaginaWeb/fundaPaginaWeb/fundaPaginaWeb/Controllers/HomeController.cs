using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models.DAO;
using fundaPaginaWeb.Models;
using System.Net;
using System.Net.Mail;

namespace fundaPaginaWeb.Controllers
{
    public class HomeController : Controller
    {
        DAO dao = new DAO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Solicitud()
        {
            return View(dao.ListSolicitud());
        }

        public ActionResult Promociones()
        {
            return View("Promociones");
        }

        public ActionResult Aceptar(string corrAdmin,string corrTienda,int idTienda)
        {

            using (MailMessage mail = new MailMessage())
            {
                Random rnd = new Random();
                int contra = rnd.Next(1, 1000);

                mail.Subject = "Subject";
                mail.Body = "Tienda Aceptada, Felicidades. " +
                    "Su contraseña es : " + contra;
                mail.From = new MailAddress(corrAdmin, "UrFind");
                mail.To.Add(new MailAddress(corrTienda));
                /* Attachment code 
                if (fileAttachment.HasFile)
                {
                    mail.Attachments.Add(new Attachment(fileAttachment.PostedFile.InputStream, fileAttachment.FileName));
                }
                */
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                NetworkCredential NetworkCred = new NetworkCredential(corrAdmin, "72941202Acm");
                smtp.Credentials = NetworkCred;
                smtp.Send(mail);
                
                dao.ActivarTienda(idTienda,contra);
            }

            return View("Solicitud",dao.ListSolicitud());
        }


        public ActionResult Rechazado(string corrAdmin, string corrTienda, int idTienda)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.Subject = "Subject";
                mail.Body = "Tienda rechazada, lo siento";
                mail.From = new MailAddress(corrAdmin, "UrFind");
                mail.To.Add(new MailAddress(corrTienda));

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                NetworkCredential NetworkCred = new NetworkCredential(corrAdmin, "72941202Acm");
                smtp.Credentials = NetworkCred;
                smtp.Send(mail);
                Random rnd = new Random();
                int contra = rnd.Next(1, 1000);
                
            }

            return View("Solicitud",dao.ListSolicitud());
        }


        public ActionResult Buscar(string buscaProducto)
        {
            dao.BuscarDataProd(buscaProducto);
            if (buscaProducto != "")    dao.AddHistorial(buscaProducto,(Int32)Session["idUser"]);
            return RedirectToAction("Index", "SearchProducto");
        }

        public void Eliminar(int id) {
            dao.EliminarFavorito(id);
           
        }
    }
}
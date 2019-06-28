using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models.DAO;
using fundaPaginaWeb.Models;

namespace fundaPaginaWeb.Controllers
{
    public class LoginController : Controller
    {
        DAO dao = new DAO();
        // GET: Login
        public ActionResult Index()
        {
           
            return View();
        }




        // GET: Login/Sesion/5
        public ActionResult Sesion(int id)
        {
            return View();
        }

        // POST: Login/Sesion/5
        [HttpPost]
        public ActionResult Sesion(String email, String pass)
        {
            try
            {
                // TODO: Add delete logic here
                var log = dao.Log(email, pass);
                var logT = dao.LogTienda(email, pass);


                if (log.idUsuario != 0)
                {
                    Session["estado"] = 1; //Por el momento con valor 1,para indicar que es cliente()Falta para admnistrador y tienda.
                    Session["userName"] = log.nNombre;
                    Session["idUser"] = log.idUsuario;
                    Session["tipo"] = log.nCargo;
                    Session["ListaFavoritos"] = dao.ListaFavoritosPorUsuario(log.idUsuario);
                    return RedirectToAction("Index", "Home");
                }
                else if (logT.idTienda != 0)
                {
                    Session["estado"] = 1;
                    Session["userName"] = logT.tCorreo;
                    Session["idUser"] = logT.idTienda;
                    Session["tipo"] = "Tienda";

                    return RedirectToAction("Index", "Tienda", new { id = logT.idTienda });
                }
                else
                {
                    Session["estado"] = 0;
                    return RedirectToAction("Index", "Login");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            List<ListaFavoritoProducto> c = null;
            Session["userName"] = "";
            Session["idUser"] = 0;
            Session["tipo"] = "";
            Session["ListaFavoritos"] = c;
            return RedirectToAction("Index", "Home");
        }
    }
}
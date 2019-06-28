using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models.DAO;

using fundaPaginaWeb.Models;

namespace fundaPaginaWeb.Controllers
{
    public class RegistrController : Controller
    {
        DAO dao = new DAO();

        // GET: Registr
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RegCliente(string Nombre, string Apellidos, string Email, string Telefono, string Contrasena)
        {
            try
            {
                Usuario usr = new Usuario();
                usr.nCargo = "Cliente";
                usr.nNombre = Nombre + " " + Apellidos;
                usr.tContrasen = Contrasena;
                usr.tCorreo = Email;
                usr.tContrasen = Contrasena;
                dao.AddUsuario(usr);
                return RedirectToAction("Index", "Home");
                
            }
            catch
            {
                return View();
            }
        }


        public ActionResult FormularioTienda()
        {
            return View("Tienda");
        }

        public ActionResult Solicitud(string ruc, string corr, string ubc, string desc, string logo)
        {
            Tienda obj = new Tienda();
            obj.tRUC = ruc;
            obj.tCorreo = corr;
            obj.dUbicacion = ubc;
            obj.tDescripcion = desc;
            obj.tcontrasena = "";
            obj.Permiso = false;
            dao.AddTienda(obj);
            return RedirectToAction("Index","Home");
        }
    }
}
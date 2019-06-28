using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models.DAO;

namespace fundaPaginaWeb.Controllers
{
    public class HistorialController : Controller
    {
        // GET: Historial
        DAO dao = new DAO();
        public ActionResult Index()
        {
            return View(dao.GetHistorial((Int32)Session["idUser"]));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models.DAO;

namespace fundaPaginaWeb.Controllers
{
    public class ProductoController : Controller
    {
        DAO dao = new DAO();

        // GET: Producto
        public ActionResult Index()
        {
            return View(dao.ProductoTienda((Int32)Session["idUser"]));
        }
    }
}
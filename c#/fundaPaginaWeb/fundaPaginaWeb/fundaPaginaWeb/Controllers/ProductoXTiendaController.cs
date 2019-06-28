using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models.DAO;
using fundaPaginaWeb.Models;

namespace fundaPaginaWeb.Controllers
{
    public class ProductoXTiendaController : Controller
    {

        DAO dao = new DAO();

        // GET: ProductoXTienda
        public ActionResult Index()
        {
            return View(dao.ListaProductoPorTienda());
        }
    }
}
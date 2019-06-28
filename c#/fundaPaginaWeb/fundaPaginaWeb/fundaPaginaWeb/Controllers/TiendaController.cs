using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models;
using fundaPaginaWeb.Models.DAO;

namespace fundaPaginaWeb.Controllers
{
    public class TiendaController : Controller
    {
        DAO dao = new DAO();
        // GET: Tienda
        public ActionResult Index()
        {
            return View(dao.ProductoTienda((Int32)Session["idUser"]));
        }

        public ActionResult AgregarProducto()
        {
            return View("AgregarProducto");
        }

        public ActionResult AddProducto(string Nombre,string imagen,string precio)
        {
            Producto obj = new Producto();
            obj.nNombre = Nombre;
            obj.nPrecio = precio;
            obj.dImagen = imagen;
            dao.AddProducto(obj);
            ProductoXTienda obj2 = new ProductoXTienda();
            obj2.Producto = obj;
            obj2.Tienda_idTienda = (Int32)Session["idUser"];
            obj2.tDisponibilidad = 1;
            dao.AddProductoTienda(obj2);
            return View("AgregarProducto");
        }
    }
}
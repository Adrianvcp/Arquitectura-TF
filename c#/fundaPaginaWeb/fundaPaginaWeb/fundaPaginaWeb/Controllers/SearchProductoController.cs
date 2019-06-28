using fundaPaginaWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundaPaginaWeb.Models;

namespace fundaPaginaWeb.Controllers
{
    public class SearchProductoController : Controller
    {
        DAO dao = new DAO();

        // GET: SearchProducto
        public ActionResult Index()
        {
            return View(dao.jsonToModel());
        }
        public ActionResult pro()
        {
            return View(dao.jsonToModel());
        }


        public ActionResult GA(string a,string b,string c)
        {
            return RedirectToAction("Index","Home");
        }

        // POST: SearchProducto/AddList
        public ActionResult AddFav(string img, string nmbre, string pr)
        {

                Random rn = new Random();
                // TODO: Add insert logic here
                Producto objP = new Producto();
                objP.nNombre = nmbre;
                objP.nPrecio = pr;
                objP.dImagen = img;
                dao.AddProducto(objP);
                var g = objP.idProducto;
                //Ingresamos a favoritos

                ListaFavoritoProducto fav = new ListaFavoritoProducto();
                fav.idProducto = g;
                fav.idUsuario = (int)Session["idUser"];
                dao.AddRitoProducto(fav);
                return RedirectToAction("Index", "Home");

        }



        // POST: SearchProducto/
        public ActionResult AddList(String img, string nmbre, string pr)
        {
            try
            {
                Random rn = new Random();
                // TODO: Add insert logic here
                Producto objP = new Producto();
                objP.nNombre = nmbre;
                objP.nPrecio = pr;
                objP.dImagen = img;
                dao.AddProducto(objP);
                var g = objP.idProducto;
                //Ingresamos a favoritos

                ListaFavoritoProducto fav = new ListaFavoritoProducto();
                fav.idProducto = g;
                fav.idUsuario = (int)Session["idUser"];
                dao.AddRitoProducto(fav);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using fundaPaginaWeb.Models;

namespace fundaPaginaWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {

        double[] arrayCS;
        List<ListaFavoritoProducto> c = null;
        List<Int16> informacionProductos = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Session_Start()
        {
            Session["tipo"] = "";
            Session["userName"] = "";
            Session["idUser"] = 0;
            Session["nCargo"] = "";
            //Session["datosPlanPago"] = ls;
            Session["aComprar"] = 0;
            Session["plazoGracia"] = 0;
            Session["listCompra"] = 0;
            Session["DatosPlanPago"] = arrayCS;
            Session["DatosFlujoNeto"] = arrayCS;
            
            Session["ListaFavoritos"] = c;
            Session["ListaComprar"] = c;



        }
    }
}

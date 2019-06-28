using Apache.NMS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace fundaPaginaWeb.Models.DAO
{
    public class DAO
    {
        
        public void RegistroUsuario(Usuario obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.Usuario.Add(obj);
                con.SaveChanges();  
            }
        }
        public void Login(Usuario obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.Usuario.Add(obj);
                con.SaveChanges();
            }
        }
        public Usuario Log(string email, string pass)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var dat = (from u in con.Usuario where u.tCorreo == email && u.tContrasen == pass select u).ToList();
                Usuario logeado = new Usuario();
                if (dat.Count() > 0)
                {
                        logeado = new Usuario();
                        logeado.idUsuario = dat[0].idUsuario;
                        logeado.nNombre = dat[0].nNombre;
                        logeado.nCargo = dat[0].nCargo;
                        logeado.tContrasen = dat[0].tContrasen;
                        logeado.tCorreo = dat[0].tCorreo;    
                }
                
                return logeado;
            }
        }

        public Tienda LogTienda(string email, string pass)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                
                var dat = (from u in con.Tienda where u.tCorreo == email && u.tcontrasena == pass select u).ToList();
                Tienda logeado = null;
                if (dat.Count() > 0)
                {
                    logeado = new Tienda();
                    logeado.tRUC = dat[0].tRUC;
                    logeado.tLogo = dat[0].tLogo;
                    logeado.dUbicacion = dat[0].dUbicacion;
                    logeado.idTienda = dat[0].idTienda;
                    logeado.Permiso = dat[0].Permiso;
                    logeado.tDescripcion = dat[0].tDescripcion;
                    logeado.tLogo = dat[0].tLogo;
                    logeado.tCorreo = dat[0].tCorreo;
                }

                return logeado;
            }
        }

        public void ActivarTienda(int id,int contrase)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var data = (from u in con.Tienda where u.idTienda == id select u).ToList();
                Tienda nuevo = (Tienda)data[0];
                nuevo.Permiso = true;
                nuevo.tcontrasena = contrase.ToString();
                con.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();
            }
        }

        public Producto buscarproducto(int id)
        {
            Producto p = null;
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var data = (from u in con.Producto where u.idProducto == id select u).ToList();

                p = new Producto();
                p.nNombre = data[0].nNombre;
                p.nPrecio = data[0].nPrecio;
                p.dImagen = data[0].dImagen;
                //p.dDescripcion = data[0].dDescripcion;
            }

            return p;
        }

        //public int cantProductosAComprar(int id)
        //{
        //    using (fasbdEntities7 con = new fasbdEntities7())
        //    {
        //        //  select COUNT(i.idProducto) from ListaFavoritoProducto i

        //        var data = (from u in con.ListaCompra where u.idCliente == id select u).ToList();

        //        return data.Count();
        //    }

        //}

        public void AddTienda(Tienda obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.Tienda.Add(obj);
                con.SaveChanges();
            }
        }

        public void AddUsuario(Usuario obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.Usuario.Add(obj);
                con.SaveChanges();
            }
        }

        public List<Tienda> ListSolicitud()
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var data = (from u in con.Tienda where u.Permiso == false select u).ToList();
                List<Tienda> lista = new List<Tienda>();
                Tienda prt = null;
                foreach (var item in data)
                {
                    prt = new Tienda();
                    prt.idTienda = item.idTienda;
                    prt.dUbicacion = item.dUbicacion;
                    prt.Permiso = item.Permiso;
                    prt.tRUC = item.tRUC;
                    prt.tCorreo = item.tCorreo;
                    prt.tDescripcion = item.tDescripcion;
                    prt.tLogo = item.tLogo;
                    lista.Add(prt);
                }
                return lista;
            }
        }
        public List<Historial> GetHistorial(int id)
        {
            Historial p = null;
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var data = (from u in con.Historial select u).ToList();
                List<Historial> lista = new List<Historial>();

                Historial prt;
                foreach (var item in data)
                {
                    prt = new Historial();
                    prt.idHistorial = item.idHistorial;
                    prt.idUsuario = item.idUsuario;
                    prt.nNomP = item.nNomP;
                    prt.Usuario = item.Usuario;
                    lista.Add(prt);
                }
                return lista;
            }
        }

        public Tienda buscarTienda(int id)
        {
            Tienda p = null;
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var data = (from u in con.Tienda where u.idTienda == id select u).ToList();

                p = new Tienda();

            }

            return p;
        }
        public List<ProductoXTienda> ListaProductoPorTienda()
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {

                var data = (from u in con.ProductoXTienda select u).ToList();
                List<ProductoXTienda> lista = new List<ProductoXTienda>();

                ProductoXTienda prt = null;
                foreach (var item in data)
                {

                    prt = new ProductoXTienda();
                    prt.idProducto = item.idProducto;
                    prt.Producto = buscarproducto(item.idProducto);
                    //prt.np = item.mPrecio;
                    //prt.tDisponibilidad = item.tDisponibilidad;
                    //prt.idTienda = item.idTienda;

                    lista.Add(prt);
                }
                return lista;
            }

        }

        public List<ProductoXTienda> ProductoTienda(int idTienda)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                var data = (from u in con.ProductoXTienda where u.Tienda_idTienda == idTienda select u).ToList();
                List<ProductoXTienda> lista = new List<ProductoXTienda>();

                ProductoXTienda prt = null;
                foreach (var item in data)
                {   prt = new ProductoXTienda();
                    prt.idProducto = item.idProducto;
                    prt.tDisponibilidad = 1;
                    prt.Producto = buscarproducto(item.idProducto);
                    prt.Tienda_idTienda = item.Tienda_idTienda;
                    prt.Tienda = item.Tienda;
                    lista.Add(prt);
                }
                return lista;
            }

        }
        public void AddProductoTienda(ProductoXTienda obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.ProductoXTienda.Add(obj);
                con.SaveChanges();
            }
        }

        //public void addPrueba( obj)
        //{
        //    using (fasbdEntities7 con = new fasbdEntities7())
        //    {
        //        con.prueba.Add(obj);
        //        con.SaveChanges();
        //    }
        //}

        public void AddProducto(Producto obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.Producto.Add(obj);
                con.SaveChanges();
            }
        }

        public void AddRitoProducto(ListaFavoritoProducto obj)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                con.ListaFavoritoProducto.Add(obj);
                con.SaveChanges();
            }
        }
        public void EliminarFavorito(int id)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                ListaFavoritoProducto nuevo = new ListaFavoritoProducto();
                var data = (from u in con.ListaFavoritoProducto where u.idListaFavorito == id select u).ToList();
                nuevo = data[0];
                
                con.Entry(nuevo).State = System.Data.Entity.EntityState.Deleted;
                con.SaveChanges();
            }
        }

        public void AddHistorial(string pro,int idU)
        {
            if (pro != null)
            {
            using (fasbdEntities7 con = new fasbdEntities7())
            {
                Historial obj = new Historial();
                obj.idUsuario = idU; 
                obj.nNomP = pro;
                con.Historial.Add(obj);
                con.SaveChanges();
            }
            }
        }
 
        //public void AddListaCP(ListaCompraXProducto obj)
        //{
        //    using (fasbdEntities7 con = new fasbdEntities7())
        //    {
        //        con.ListaCompraXProducto.Add(obj);
        //        con.SaveChanges();
        //    }
        //}

        //public List<Producto> ProductoLista()
        //{
        //    using (fasbdEntities7 con = new fasbdEntities7())
        //    {

        //        var data = (from u in con.ListaCompraXProducto where u.idListaCompra == 2 select u).ToList();
        //        List<Producto> lista = new List<Producto>();

        //        Producto compra = null;
        //        foreach (var item in data)
        //        {

        //            compra = new Producto();
        //            compra = buscarproducto(item.idProducto);


        //            lista.Add(compra);
        //        }
        //        return lista;
        //    }

        //}

        //public List<ListaCompra> listaCompra(int id)
        //{
        //    using (fasbdEntities7 con = new fasbdEntities7())
        //    {

        //        var data = (from u in con.ListaCompra where u.idListaCompra == id select u).ToList();
        //        List<ListaCompra> lista = new List<ListaCompra>();

        //        ListaCompra compra = null;
        //        foreach (var item in data)
        //        {

        //            compra = new ListaCompra();
        //            //compra.ListaCompraXProducto = dao
        //            compra.idListaCompra = item.idListaCompra;
        //            //compra.idTienda = buscarproducto(item.idProducto);
        //            compra.idCliente = item.idCliente;
        //            compra.nNombre = item.nNombre;


        //            lista.Add(compra);
        //        }
        //        return lista;
        //    }

        //}
        public List<ListaFavoritoProducto> ListaFavoritosPorUsuario(int idUser)
        {
            using (fasbdEntities7 con = new fasbdEntities7())
            {

                var data = (from u in con.ListaFavoritoProducto where u.idUsuario == idUser select u).ToList();
                List<ListaFavoritoProducto> lista = new List<ListaFavoritoProducto>();

                ListaFavoritoProducto prt = null;
                foreach (var item in data)
                {
                    prt = new ListaFavoritoProducto();
                    prt.idListaFavorito = item.idListaFavorito;
                    prt.idProducto = item.idProducto;
                    prt.Producto = buscarproducto(item.idProducto);

                    prt.idUsuario = item.idUsuario;
                    
                    lista.Add(prt);
                }
                return lista;
            }
        }
        public void BuscarDataProd(string buscarproducto)
        {
            string topic = "queue_name";

            string brokerUri = $"activemq:tcp://localhost:61616";
            NMSConnectionFactory factory = new NMSConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();

                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetTopic(topic))
                using (IMessageProducer producer = session.CreateProducer(dest))
                {
                    producer.DeliveryMode = MsgDeliveryMode.NonPersistent;
                    producer.Send(session.CreateTextMessage(buscarproducto));
                }
            }
            Thread.Sleep(TimeSpan.FromSeconds(16));
        }
        public List<Producto> jsonToModel()
        {
            string filejson = File.ReadAllText(@"C:\Users\Kath\Desktop\data.json");
            //Rec cambiar int bd a float para los precios
            List<Producto> listProductos = JsonConvert.DeserializeObject<List<Producto>>(filejson);

            return listProductos;


        }
    }
}
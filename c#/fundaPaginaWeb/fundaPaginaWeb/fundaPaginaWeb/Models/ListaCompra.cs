//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fundaPaginaWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListaCompra
    {
        public int idListaCompra { get; set; }
        public string nNombre { get; set; }
        public Nullable<int> Usuario_idUsuario { get; set; }
        public Nullable<int> idTienda { get; set; }
    
        public virtual Tienda Tienda { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ListaCompraXProducto ListaCompraXProducto { get; set; }
    }
}

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
    
    public partial class ListaFavoritoProducto
    {
        public int idListaFavorito { get; set; }
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

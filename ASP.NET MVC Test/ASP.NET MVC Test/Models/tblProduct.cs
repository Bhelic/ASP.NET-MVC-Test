//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NET_MVC_Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        public int ProdId { get; set; }
        public string ProdNombre { get; set; }
        public int CatId { get; set; }
        public double Precio { get; set; }
        public string ProdObservacion { get; set; }
    
        public virtual tblProductCategory tblProductCategory { get; set; }
    }
}
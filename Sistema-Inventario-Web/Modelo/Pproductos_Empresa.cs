//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pproductos_Empresa
    {
        public int id { get; set; }
        public int Producto_id { get; set; }
        public int Empresa_id { get; set; }
        public bool Estatus { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual Productos Productos { get; set; }
    }
}

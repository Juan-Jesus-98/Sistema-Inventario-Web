//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Impuestos
    {
        public int id { get; set; }
        public string Impuestos1 { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Monto { get; set; }
        public Nullable<int> Venta_id { get; set; }
        public Nullable<int> Compra_id { get; set; }
        public bool Estatus { get; set; }
    
        public virtual Compras Compras { get; set; }
        public virtual Ventas Ventas { get; set; }
    }
}

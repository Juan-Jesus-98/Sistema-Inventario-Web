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
    
    public partial class Compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compras()
        {
            this.Impuestos = new HashSet<Impuestos>();
        }
    
        public int id { get; set; }
        public string Compras1 { get; set; }
        public int Producto_id { get; set; }
        public int Empresa_id { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> CostoUnidad { get; set; }
        public Nullable<decimal> CostoTotal { get; set; }
        public Nullable<decimal> CostoNeto { get; set; }
        public Nullable<decimal> GranTotal { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual Productos Productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Impuestos> Impuestos { get; set; }
    }
}

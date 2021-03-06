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
    
    public partial class Empresas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresas()
        {
            this.Compras = new HashSet<Compras>();
            this.Productos_Empresa = new HashSet<Productos_Empresa>();
        }
    
        public int id { get; set; }
        public string NombreEmpresa { get; set; }
        public string CorreoElectronicos { get; set; }
        public string Telefono { get; set; }
        public string Moneda { get; set; }
        public Nullable<int> ZonaHoraria_id { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Tipo_id { get; set; }
    
        public virtual Catalogo Catalogo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras> Compras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productos_Empresa> Productos_Empresa { get; set; }
    }
}

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
    
    public partial class Anexos
    {
        public int id { get; set; }
        public string Archivo { get; set; }
        public Nullable<int> Prducto_id { get; set; }
        public Nullable<bool> Estatus { get; set; }
    
        public virtual Productos Productos { get; set; }
    }
}

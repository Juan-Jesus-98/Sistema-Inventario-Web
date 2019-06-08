using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Model
{
    internal class Entidades : DbContext
    {
        public Entidades()
            : base("name=Entidades")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Anexos> Anexos { get; set; }
        public virtual DbSet<Catalogo> Catalogos { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Impuestos> Impuestos { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Productos_Empresa> Productos_Empresas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
    }
}
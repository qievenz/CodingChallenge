namespace DataEntityModel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FormaGeometricaDBContext : DbContext
    {
        public FormaGeometricaDBContext()
            : base("name=FormaGeometricaDBContext")
        {
        }

        public virtual DbSet<Figura> Figura { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Figura>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Figura>()
                .Property(e => e.Area)
                .IsFixedLength();

            modelBuilder.Entity<Figura>()
                .Property(e => e.Perimetro)
                .IsFixedLength();
        }
    }
}

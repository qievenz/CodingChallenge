namespace Figura.Models
{
    using System.Data.Entity;

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

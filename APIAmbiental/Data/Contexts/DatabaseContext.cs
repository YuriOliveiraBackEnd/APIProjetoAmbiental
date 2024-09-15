using APIAmbiental.Models;
using Microsoft.EntityFrameworkCore;


namespace APIAmbiental.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<CondicoesAmbientaisModel> CondicoesAmbientais { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CondicoesAmbientaisModel>(entity =>
            {
                entity.ToTable("CondicoesAmbientais");
                entity.HasKey(e => e.id);
                entity.Property(e => e.qualidadeAr).HasColumnType("NVARCHAR2(10)").IsRequired();
                entity.Property(e => e.umidade).HasColumnType("NVARCHAR2(10)").IsRequired();
                entity.Property(e => e.temperatura).HasColumnType("NVARCHAR2(10)").IsRequired();
                entity.Property(e => e.contatoEmergencia).HasColumnType("NVARCHAR2(15)").IsRequired();
                entity.Property(e => e.desastreNatural).HasColumnType("NVARCHAR2(15)").IsRequired();                      
    });

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SistemaPropostas.API.Models;

namespace SistemaPropostas.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        // 👇 AGORA SIM, dentro da classe
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                // 👇 Mapeando cada campo
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Documento).HasColumnName("documento");
                entity.Property(e => e.TipoPessoa).HasColumnName("tipopessoa");

                // 👇 UNIQUE
                entity.HasIndex(e => e.Documento).IsUnique();
            });
        }
    }
}
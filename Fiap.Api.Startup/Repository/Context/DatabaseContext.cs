using Fiap.Api.Startup.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Startup.Repository.Context;

public class DatabaseContext : DbContext
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Endereco)
            .WithOne(u => u.Usuario)
            .IsRequired(false)
            .HasForeignKey<Endereco>(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Veiculos)
            .WithOne(v => v.Usuario)
            .HasForeignKey(v => v.UsuarioId);

        modelBuilder.Entity<Proposta>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Proposta)
            .HasForeignKey(p => p.UsuarioId);

        modelBuilder.Entity<Proposta>()
            .HasOne(p => p.Veiculo)
            .WithMany(v => v.Proposta)
            .HasForeignKey(p => p.VeiculoId);

    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected DatabaseContext()
    {
    }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Veiculo> Veiculo { get; set; }
    public DbSet<Proposta> Proposta { get; set; }
}

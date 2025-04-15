using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Entities;
using Reservas.Infra.Data.Configurations;

namespace Reservas.Infrastructure.Data;
public class ReservaDbContext : DbContext
{
    public ReservaDbContext(DbContextOptions<ReservaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Buffet> Buffets { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new BuffetConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
    }
}

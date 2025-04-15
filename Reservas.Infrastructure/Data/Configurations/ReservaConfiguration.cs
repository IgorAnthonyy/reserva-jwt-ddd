using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Domain.Entities;

namespace Reservas.Infra.Data.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {

        builder.HasKey(r => r.Id);

        builder.Property(r => r.DataReserva)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(r => r.QuantidadePessoas)
            .IsRequired()
            .HasDefaultValue(1);

        builder.HasOne(r => r.Usuario)
            .WithMany(u => u.Reservas)
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Buffet)
            .WithMany(b => b.Reservas)
            .HasForeignKey(r => r.BuffetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

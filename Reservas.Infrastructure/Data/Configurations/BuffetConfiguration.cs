using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Domain.Entities;

namespace Reservas.Infra.Data.Configurations;

public class BuffetConfiguration : IEntityTypeConfiguration<Buffet>
{
    public void Configure(EntityTypeBuilder<Buffet> builder)
    {
        
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Nome).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Descricao).IsRequired().HasMaxLength(500);

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reservas.Infrastructure.Data;

namespace Reservas.Infrastructure.Data;

public class ReservaDbContextFactory : IDesignTimeDbContextFactory<ReservaDbContext>
{
    public ReservaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReservaDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ReservasDB;User Id=sa;Password=fUtur@13;TrustServerCertificate=True;");

        return new ReservaDbContext(optionsBuilder.Options);
    }
}

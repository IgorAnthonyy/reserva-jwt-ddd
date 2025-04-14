using Mapster;
using Reservas.Application.DTO;
using Reservas.Domain.Entities;

public static class ReservaProfile
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<ReservaDTORequest, Reserva>.NewConfig();
        TypeAdapterConfig<Reserva, ReservaDTOResponse>.NewConfig();
        TypeAdapterConfig<Usuario, UsuarioDTOResponse>.NewConfig();
        TypeAdapterConfig<Buffet, BuffetDTOResponse>.NewConfig();
    }
}

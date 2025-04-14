using Mapster;
using Reservas.Application.DTO;
using Reservas.Domain.Entities;

public static class BuffetProfile
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<Buffet, BuffetDTOResponse>.NewConfig();
        TypeAdapterConfig<BuffetDTORequest, Buffet>.NewConfig();
    }
}

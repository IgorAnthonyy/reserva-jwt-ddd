using Mapster;
using Reservas.Application.DTO;
using Reservas.Domain.Entities;

public static class UsuarioProfile
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<Usuario, UsuarioDTOResponse>.NewConfig();
        
        TypeAdapterConfig<UsuarioDTORequest, Usuario>.NewConfig();
    }
}

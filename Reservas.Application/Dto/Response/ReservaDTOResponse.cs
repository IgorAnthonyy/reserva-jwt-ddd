
namespace Reservas.Application.DTO;

public class ReservaDTOResponse
{
    public int Id { get; set; }
    public DateTime DataReserva { get; set; }

    public int QuantidadePessoas { get; set; }

    public int UsuarioId { get; set; }

    public UsuarioDTOResponse Usuario { get; set; }
    public int BuffetId { get; set; }

    public BuffetDTOResponse Buffet { get; set; }

}
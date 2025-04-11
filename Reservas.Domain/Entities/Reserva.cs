namespace Reservas.Domain.Entities;

public class Reserva
{
    public int Id { get; set; }
    public DateTime DataReserva { get; set; }
    public int QuantidadePessoas { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int BuffetId { get; set; }
    public Buffet Buffet { get; set; }
}

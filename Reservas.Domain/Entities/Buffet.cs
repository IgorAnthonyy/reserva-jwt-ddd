namespace Reservas.Domain.Entities;
public class Buffet
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

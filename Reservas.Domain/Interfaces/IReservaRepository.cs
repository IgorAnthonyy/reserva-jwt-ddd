using Reservas.Domain.Entities;

public interface IReservaRepository
{
    Task<Reserva> BuscarPorId(int id);
    Task<List<Reserva>> BuscarTodos();

    Task<Reserva> BuscarPorIdComRelacionamentos(int id);
    Task<List<Reserva>> BuscarTodosComRelacionamentos();

    Task<Reserva> Adicionar(Reserva reserva);
    Task<Reserva> Atualizar(Reserva reserva);
    Task Deletar(int id);
}

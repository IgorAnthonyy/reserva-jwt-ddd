namespace Reservas.Domain.Interfaces;

using Reservas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReservaRepository
{
    Task<Reserva> BuscarPorId(int id);
    Task<List<Reserva>> BuscarTodos();
    Task<Reserva> Adicionar(Reserva reserva);
    Task<Reserva> Atualizar(Reserva reserva);
    Task Deletar(int id);
}

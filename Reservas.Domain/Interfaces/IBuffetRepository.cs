namespace Reservas.Domain.Interfaces;
using Reservas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBuffetRepository
{
    Task<Buffet> BuscarPorId(int id);
    Task<List<Buffet>> BuscarTodos();
    Task<Buffet> Adicionar(Buffet buffet);
    Task<Buffet> Atualizar(Buffet buffet);
    Task Deletar(int id);
};

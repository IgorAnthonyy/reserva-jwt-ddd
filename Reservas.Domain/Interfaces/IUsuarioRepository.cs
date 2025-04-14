namespace Reservas.Domain.Interfaces;

using Reservas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioRepository
{
    Task<Usuario> BuscarPorId(int id);
    Task<List<Usuario>> BuscarTodos();
    Task<Usuario> Adicionar(Usuario usuario);
    Task<Usuario> Atualizar(Usuario usuario);
    Task Deletar(int id);

    Task<Usuario> BuscarPorEmail(string email);
}

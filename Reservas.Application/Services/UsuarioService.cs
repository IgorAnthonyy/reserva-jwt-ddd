using Reservas.Domain.Entities;
using Reservas.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Reservas.Application.Services;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly PasswordHasher<Usuario> _passwordHasher = new PasswordHasher<Usuario>();
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> ObterUsuarioPorId(int id)
    {
        return await _usuarioRepository.BuscarPorId(id);
    }
    public async Task<List<Usuario>> ObterTodosUsuarios()
    {
        return await _usuarioRepository.BuscarTodos();
    }
    public async Task<Usuario> CriarUsuario(Usuario usuario)
    {
        usuario.Senha = _passwordHasher.HashPassword(usuario, usuario.Senha);
        return await _usuarioRepository.Adicionar(usuario);
    }
    public async Task<Usuario> AtualizarUsuario(Usuario usuario)
    {
        usuario.Senha = _passwordHasher.HashPassword(usuario, usuario.Senha);
        return await _usuarioRepository.Atualizar(usuario);
    }
    public async Task DeletarUsuario(int id)
    {
        await _usuarioRepository.Deletar(id);
    }

    public async Task<Usuario> ObterUsuarioPorEmail(string email)
    {
        return await _usuarioRepository.BuscarPorEmail(email);
    }
}
using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Entities;
using Reservas.Domain.Interfaces;
using Reservas.Infrastructure.Data;

namespace Reservas.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ReservaDbContext _context;

    public UsuarioRepository(ReservaDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> BuscarPorId(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<List<Usuario>> BuscarTodos()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> Adicionar(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> Atualizar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task Deletar(int id)
    {
        var usuario = await BuscarPorId(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Usuario> BuscarPorEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }
}
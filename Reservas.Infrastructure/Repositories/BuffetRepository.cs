using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Entities;
using Reservas.Domain.Interfaces;
using Reservas.Infrastructure.Data;

namespace Reservas.Infrastructure.Repositories;

public class BuffetRepository : IBuffetRepository
{
    private readonly ReservaDbContext _context;

    public BuffetRepository(ReservaDbContext context)
    {
        _context = context;
    }

    public async Task<Buffet> BuscarPorId(int id)
    {
        return await _context.Buffets.FindAsync(id);
    }

    public async Task<List<Buffet>> BuscarTodos()
    {
        return await _context.Buffets.ToListAsync();
    }

    public async Task<Buffet> Adicionar(Buffet buffet)
    {
        await _context.Buffets.AddAsync(buffet);
        await _context.SaveChangesAsync();
        return buffet;
    }

    public async Task<Buffet> Atualizar(Buffet buffet)
    {
        _context.Buffets.Update(buffet);
        await _context.SaveChangesAsync();
        return buffet;
    }

    public async Task Deletar(int id)
    {
        var buffet = await BuscarPorId(id);
        if (buffet != null)
        {
            _context.Buffets.Remove(buffet);
            await _context.SaveChangesAsync();
        }
    }
}
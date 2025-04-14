using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Entities;
using Reservas.Domain.Interfaces;
using Reservas.Infrastructure.Data;

public class ReservaRepository : IReservaRepository
{
    private readonly ReservaDbContext _context;

    public ReservaRepository(ReservaDbContext context)
    {
        _context = context;
    }

    public async Task<Reserva> BuscarPorId(int id)
    {
        return await _context.Reservas.FindAsync(id);
    }

    public async Task<List<Reserva>> BuscarTodos()
    {
        return await _context.Reservas.ToListAsync();
    }

    public async Task<Reserva> BuscarPorIdComRelacionamentos(int id)
    {
        return await _context.Reservas
            .Include(r => r.Usuario)
            .Include(r => r.Buffet)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Reserva>> BuscarTodosComRelacionamentos()
    {
        return await _context.Reservas
            .Include(r => r.Usuario)
            .Include(r => r.Buffet)
            .ToListAsync();
    }

    public async Task<Reserva> Adicionar(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task<Reserva> Atualizar(Reserva reserva)
    {
        _context.Reservas.Update(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task Deletar(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}

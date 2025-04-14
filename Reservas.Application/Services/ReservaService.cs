namespace Reservas.Application.Services
{
    using Reservas.Domain.Entities;
    using Reservas.Domain.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Reserva> ObterReservaPorId(int id)
        {
            return await _reservaRepository.BuscarPorIdComRelacionamentos(id);
        }

        public async Task<List<Reserva>> ObterTodasReservas()
        {
            return await _reservaRepository.BuscarTodosComRelacionamentos();
        }

        public async Task<Reserva> CriarReserva(Reserva reserva)
        {
            return await _reservaRepository.Adicionar(reserva);
        }

        public async Task<Reserva> AtualizarReserva(Reserva reserva)
        {
            return await _reservaRepository.Atualizar(reserva);
        }

        public async Task DeletarReserva(int id)
        {
            await _reservaRepository.Deletar(id);
        }
    }
}

namespace Reservas.Application.Services
{
    using Reservas.Domain.Entities;
    using Reservas.Domain.Interfaces;

    public class BuffetService 
    {
        private readonly IBuffetRepository _buffetRepository;
        public BuffetService(IBuffetRepository buffetRepository)
        {
            _buffetRepository = buffetRepository;
        }

        public async Task<Buffet> ObterBuffetPorId(int id)
        {
            return await _buffetRepository.BuscarPorId(id);
        }
        public async Task<List<Buffet>> ObterTodosBuffets()
        {
            return await _buffetRepository.BuscarTodos();
        }
        public async Task<Buffet> CriarBuffet(Buffet buffet)
        {
            return await _buffetRepository.Adicionar(buffet);
        }
        public async Task<Buffet> AtualizarBuffet(Buffet buffet)
        {
            return await _buffetRepository.Atualizar(buffet);
        }
        public async Task DeletarBuffet(int id)
        {
            await _buffetRepository.Deletar(id);
        }
    }
}
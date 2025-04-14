using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.DTO;
using Reservas.Application.Services;

namespace Reservas.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservaController : ControllerBase
{
    private readonly ReservaService _reservaService;

    public ReservaController(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> BuscarTodasReservas()
    {
        var reservas = await _reservaService.ObterTodasReservas();
        var reservasDto = reservas.Adapt<List<ReservaDTOResponse>>();
        return Ok(reservasDto);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarReservaPorId(int id)
    {
        var reserva = await _reservaService.ObterReservaPorId(id);
        if (reserva == null)
            return NotFound();

        var reservaDto = reserva.Adapt<ReservaDTOResponse>();
        return Ok(reservaDto);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CriarReserva([FromBody] ReservaDTORequest reservaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reserva = reservaDto.Adapt<Domain.Entities.Reserva>();
        var reservaCriada = await _reservaService.CriarReserva(reserva);
        var reservaRelacionamento = await _reservaService.ObterReservaPorId(reservaCriada.Id);
        var reservaResponse = reservaRelacionamento.Adapt<ReservaDTOResponse>();
        return CreatedAtAction(nameof(BuscarReservaPorId), new { id = reservaResponse.Id }, reservaResponse);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarReserva(int id, [FromBody] ReservaDTORequest reservaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reservaExistente = await _reservaService.ObterReservaPorId(id);
        if (reservaExistente == null)
            return NotFound();

        reservaDto.Adapt(reservaExistente);
        var reservaAtualizada = await _reservaService.AtualizarReserva(reservaExistente);
        var reservaRelacionamento = await _reservaService.ObterReservaPorId(reservaAtualizada.Id);
        var reservaResponse = reservaRelacionamento.Adapt<ReservaDTOResponse>();
        return Ok(reservaResponse);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reserva = await _reservaService.ObterReservaPorId(id);
        if (reserva == null)
            return NotFound();

        await _reservaService.DeletarReserva(id);
        return NoContent();
    }
}

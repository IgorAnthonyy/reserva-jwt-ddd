using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.DTO;
using Reservas.Application.Services;

namespace Reservas.API.Controllers;
[ApiController]
[Route("[controller]")]
public class BuffetController : ControllerBase
{
    private readonly BuffetService _buffetService;

    public BuffetController(BuffetService buffetService)
    {
        _buffetService = buffetService;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> BuscarTodosBuffets()
    {
        var buffets = await _buffetService.ObterTodosBuffets();
        var buffetsDto = buffets.Adapt<List<BuffetDTOResponse>>();
        return Ok(buffetsDto);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarBuffetPorId(int id)
    {
        var buffet = await _buffetService.ObterBuffetPorId(id);
        if (buffet == null) return NotFound();
        var buffetDto = buffet.Adapt<BuffetDTOResponse>();
        return Ok(buffetDto);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CriarBuffet([FromBody] BuffetDTORequest buffetDto)
    {
        var buffet = buffetDto.Adapt<Domain.Entities.Buffet>();
        var buffetCriado = await _buffetService.CriarBuffet(buffet);
        var buffetResponse = buffetCriado.Adapt<BuffetDTOResponse>();
        return CreatedAtAction(nameof(BuscarBuffetPorId), new { id = buffetResponse.Id }, buffetResponse);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarBuffet(int id, [FromBody] BuffetDTORequest buffetDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var buffet = await _buffetService.ObterBuffetPorId(id);
        if (buffet == null) return NotFound();

        buffetDto.Adapt(buffet); // Mapster
        var buffetAtualizado = await _buffetService.AtualizarBuffet(buffet);
        var buffetResponse = buffetAtualizado.Adapt<BuffetDTOResponse>();
        return Ok(buffetResponse);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var buffet = await _buffetService.ObterBuffetPorId(id);
        if (buffet == null) return NotFound();

        await _buffetService.DeletarBuffet(id);
        return NoContent();
    }
}
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.DTO;
using Reservas.Application.Services;
using Reservas.Domain.Entities;
using Reservas.Infrastructure.Auth;

namespace Reservas.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly PasswordHasher<Usuario> _passwordHasher = new PasswordHasher<Usuario>();

    private readonly UsuarioService _usuarioService;
    private readonly TokenService _tokenService;

    public UsuarioController(UsuarioService usuarioService, TokenService tokenService)
    {
        _usuarioService = usuarioService;
        _tokenService = tokenService;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> BuscarTodosUsuarios()
    {
        var usuarios = await _usuarioService.ObterTodosUsuarios();
        var usuariosDto = usuarios.Adapt<List<UsuarioDTOResponse>>();
        return Ok(usuariosDto);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarUsuarioPorId(int id)
    {
        var usuario = await _usuarioService.ObterUsuarioPorId(id);
        if (usuario == null) return NotFound();
        var usuarioDto = usuario.Adapt<UsuarioDTOResponse>();
        return Ok(usuarioDto);
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDTORequest usuarioDto)
    {
        var usuario = usuarioDto.Adapt<Usuario>();
        var usuarioCriado = await _usuarioService.CriarUsuario(usuario);
        var usuarioResponse = usuarioCriado.Adapt<UsuarioDTOResponse>();
        return CreatedAtAction(nameof(BuscarUsuarioPorId), new { id = usuarioResponse.Id }, usuarioResponse);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDTORequest usuarioDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var usuario = await _usuarioService.ObterUsuarioPorId(id);
        if (usuario == null) return NotFound();

        usuarioDto.Adapt(usuario); // Mapster
        var usuarioAtualizado = await _usuarioService.AtualizarUsuario(usuario);
        var usuarioResponse = usuarioAtualizado.Adapt<UsuarioDTOResponse>();
        return Ok(usuarioResponse);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.ObterUsuarioPorId(id);
        if (usuario == null) return NotFound();

        await _usuarioService.DeletarUsuario(id);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var usuario = await _usuarioService.ObterUsuarioPorEmail(request.Email);

        if (usuario == null)
            return Unauthorized("E-mail ou senha inválidos.");

        var passwordHasher = new PasswordHasher<Usuario>();
        var result = passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, request.Senha);

        if (result == PasswordVerificationResult.Failed)
            return Unauthorized("E-mail ou senha inválidos.");

        var token = _tokenService.GerarToken(usuario);
        return Ok(new LoginResponse
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Nome = usuario.Nome,
            Telefone = usuario.Telefone,
            Token = token
        });
    }

}

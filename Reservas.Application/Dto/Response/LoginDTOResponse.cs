namespace Reservas.Application.DTO;



public class LoginResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Token { get; set; }
}
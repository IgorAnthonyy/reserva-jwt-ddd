using System.ComponentModel.DataAnnotations;

namespace Reservas.Application.DTO;

public class ReservaDTORequest
{
    [Required(ErrorMessage = "O campo DataReserva é obrigatório.")]
    [DataType(DataType.Date, ErrorMessage = "O campo DataReserva deve ser uma data válida.")]
    public DateTime DataReserva { get; set; }
    [Required(ErrorMessage = "O campo QuantidadePessoas é obrigatório.")]
    [Range(1, 1000, ErrorMessage = "O campo QuantidadePessoas deve estar entre 1 e 1000.")]
    public int QuantidadePessoas { get; set; }
    [Required(ErrorMessage = "O campo UsuarioId é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo UsuarioId deve ser um número positivo.")]
    public int UsuarioId { get; set; }
    [Required(ErrorMessage = "O campo BuffetId é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo BuffetId deve ser um número positivo.")]
    public int BuffetId { get; set; }
}
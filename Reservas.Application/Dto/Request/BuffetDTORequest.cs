using System.ComponentModel.DataAnnotations;


namespace Reservas.Application.DTO;
public class BuffetDTORequest
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
    [StringLength(500, ErrorMessage = "O campo Descrição deve ter no máximo 500 caracteres.")]
    public string Descricao { get; set; }
}

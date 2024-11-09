using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Application.Dtos;

public class MedicoDto
{
    [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Campo deve ter no mínimo 5 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "A especialidade pode ter no máximo 50 caracteres")]
    public string? Especialidade { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Crm)} é obrigatório")]
    [StringLength(20, ErrorMessage = "O CRM pode ter no máximo 20 caracteres")]
    public string Crm { get; set; } = string.Empty;
}

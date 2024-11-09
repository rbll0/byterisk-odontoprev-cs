using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Application.Dtos;

public class ExameDto
{
    [Required(ErrorMessage = $"Campo {nameof(DataExame)} é obrigatório")]
    public DateTime DataExame { get; set; }

    [StringLength(50, ErrorMessage = "O tipo de exame pode ter no máximo 50 caracteres")]
    public string? TipoExame { get; set; }

    [StringLength(20, ErrorMessage = "O resultado do exame pode ter no máximo 20 caracteres")]
    public string? ResultadoExame { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(BeneficiarioId)} é obrigatório")]
    public int BeneficiarioId { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(MedicoId)} é obrigatório")]
    public int MedicoId { get; set; }
}

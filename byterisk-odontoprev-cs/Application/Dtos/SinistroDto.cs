using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Application.Dtos;

public class SinistroDto
{
    [Required(ErrorMessage = $"Campo {nameof(DataSinistro)} é obrigatório")]
    public DateTime DataSinistro { get; set; }

    [StringLength(50, ErrorMessage = "O tipo de sinistro pode ter no máximo 50 caracteres")]
    public string? TipoSinistro { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(ValorSinistro)} é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor do sinistro deve ser maior que zero")]
    public decimal ValorSinistro { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(BeneficiarioId)} é obrigatório")]
    public int BeneficiarioId { get; set; }
}

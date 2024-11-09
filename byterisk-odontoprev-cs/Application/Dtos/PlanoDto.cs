using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Application.Dtos;

public class PlanoDto
{
    [Required(ErrorMessage = $"Campo {nameof(NomePlano)} é obrigatório")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo deve ter no mínimo 5 caracteres")]
    public string NomePlano { get; set; } = string.Empty;

    [Required(ErrorMessage = $"Campo {nameof(TipoPlano)} é obrigatório")]
    [StringLength(50, ErrorMessage = "O tipo de plano pode ter no máximo 50 caracteres")]
    public string TipoPlano { get; set; } = string.Empty;

    [Required(ErrorMessage = $"Campo {nameof(ValorMensal)} é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor mensal deve ser maior que zero")]
    public decimal ValorMensal { get; set; }
}

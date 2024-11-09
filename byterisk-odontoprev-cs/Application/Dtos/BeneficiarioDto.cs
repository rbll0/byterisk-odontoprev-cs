using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Application.Dtos;

public class BeneficiarioDto
{
    [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Campo deve ter no mínimo 5 caracteres")]
    public string Nome { get; set; } = string.Empty;
        
    [Required(ErrorMessage = $"Campo {nameof(DataNascimento)} é obrigatório")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Cpf)} é obrigatório")]
    [StringLength(11, ErrorMessage = "CPF deve ter 11 caracteres")]
    public string Cpf { get; set; } = string.Empty;

    public string? Telefone { get; set; }

    [EmailAddress(ErrorMessage = "O email não é válido")]
    public string? Email { get; set; }

    public string? Endereco { get; set; }

    public string? Ranking { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(PlanoId)} é obrigatório")]
    public int PlanoId { get; set; }
}

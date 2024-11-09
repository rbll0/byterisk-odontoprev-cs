using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace byterisk_odontoprev_cs.Domain.Entities;

[Table("BENEFICIARIO")]
public class BeneficiarioEntity
{
    [Key]
    [Column("ID_BENEFICIARIO")] // Nome correto da coluna no Oracle
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [StringLength(11)]
    public string Cpf { get; set; } = string.Empty;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Endereco { get; set; }

    public string? Ranking { get; set; }

    // Chave estrangeira
    public int PlanoId { get; set; }
    public PlanoEntity? Plano { get; set; }

    // Relacionamentos com outras entidades
    public ICollection<SinistroEntity>? Sinistros { get; set; }
    public ICollection<ConsultaEntity>? Consultas { get; set; }
    public ICollection<ExameEntity>? Exames { get; set; }
}


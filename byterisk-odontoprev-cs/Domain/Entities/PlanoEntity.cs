using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace byterisk_odontoprev_cs.Domain.Entities;

[Table("PLANO")]
public class PlanoEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string NomePlano { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string TipoPlano { get; set; } = string.Empty;

    [Required]
    public decimal ValorMensal { get; set; }

    // Relacionamento com beneficiários
    public ICollection<BeneficiarioEntity>? Beneficiarios { get; set; }
}

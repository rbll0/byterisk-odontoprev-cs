using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace byterisk_odontoprev_cs.Domain.Entities;

[Table("SINISTRO")]
public class SinistroEntity
{
    [Key]
    public int Id { get; set; }

    public int BeneficiarioId { get; set; }
    public BeneficiarioEntity? Beneficiario { get; set; }

    [Required]
    public DateTime DataSinistro { get; set; }

    [StringLength(50)]
    public string? TipoSinistro { get; set; }

    [Column("VALOR_SINISTRO")]
    public decimal ValorSinistro { get; set; }

}


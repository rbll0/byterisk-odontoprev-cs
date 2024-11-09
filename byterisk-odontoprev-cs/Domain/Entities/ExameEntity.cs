using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace byterisk_odontoprev_cs.Domain.Entities;

[Table("EXAME")]
public class ExameEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DataExame { get; set; }

    [StringLength(50)]
    public string? TipoExame { get; set; }

    [StringLength(20)]
    public string? ResultadoExame { get; set; }

    // Chaves estrangeiras
    public int BeneficiarioId { get; set; }
    public BeneficiarioEntity? Beneficiario { get; set; }

    public int MedicoId { get; set; }
    public MedicoEntity? Medico { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace byterisk_odontoprev_cs.Domain.Entities;

[Table("PROFISSIONAL")]
public class MedicoEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Especialidade { get; set; }

    [Required]
    [StringLength(20)]
    public string Crm { get; set; } = string.Empty;

    // Relacionamentos
    public ICollection<ConsultaEntity>? Consultas { get; set; }
    public ICollection<ExameEntity>? Exames { get; set; }
}

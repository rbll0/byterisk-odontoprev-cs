using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace byterisk_odontoprev_cs.Domain.Entities;

[Table("CONSULTA")]
public class ConsultaEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DataConsulta { get; set; }

    [StringLength(50)]
    public string? MotivoConsulta { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    // Chaves estrangeiras
    public int BeneficiarioId { get; set; }
    public BeneficiarioEntity? Beneficiario { get; set; }

    // Alterando de MedicoId para ProfissionalId (conforme o banco de dados)
    public int MedicoId { get; set; } // Altere o nome da propriedade, se necessário, para `ProfissionalId`
    public MedicoEntity? Medico { get; set; } // Ou `ProfissionalEntity`, dependendo de como está sua classe
}

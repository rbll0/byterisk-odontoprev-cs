using System.ComponentModel.DataAnnotations;

namespace byterisk_odontoprev_cs.Application.Dtos;

public class ConsultaDto
{
    [Required(ErrorMessage = $"Campo {nameof(DataConsulta)} é obrigatório")]
    public DateTime DataConsulta { get; set; }

    [StringLength(50, ErrorMessage = "O motivo da consulta pode ter no máximo 50 caracteres")]
    public string? MotivoConsulta { get; set; }

    [StringLength(20, ErrorMessage = "O status da consulta pode ter no máximo 20 caracteres")]
    public string? Status { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(BeneficiarioId)} é obrigatório")]
    public int BeneficiarioId { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(MedicoId)} é obrigatório")]
    public int MedicoId { get; set; }
}

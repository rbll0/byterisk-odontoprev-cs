using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Application.Interfaces;

public interface IConsultaApplicationService
{
    IEnumerable<ConsultaEntity>? ObterTodasConsultas();
    ConsultaEntity? ObterConsultaPorId(int id);
    ConsultaEntity? SalvarDadosConsulta(ConsultaDto entity);
    ConsultaEntity? EditarDadosConsulta(int id, ConsultaDto entity);
    ConsultaEntity? DeletarDadosConsulta(int id);
}

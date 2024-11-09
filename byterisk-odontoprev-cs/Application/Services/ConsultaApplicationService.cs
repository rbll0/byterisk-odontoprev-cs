using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;

namespace byterisk_odontoprev_cs.Application.Services;

public class ConsultaApplicationService : IConsultaApplicationService
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaApplicationService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public ConsultaEntity? DeletarDadosConsulta(int id)
    {
        return _consultaRepository.DeletarDados(id);
    }

    public ConsultaEntity? EditarDadosConsulta(int id, ConsultaDto entity)
    {
        var consulta = new ConsultaEntity
        {
            Id = id,
            DataConsulta = entity.DataConsulta,
            MotivoConsulta = entity.MotivoConsulta,
            Status = entity.Status,
            BeneficiarioId = entity.BeneficiarioId,
            MedicoId = entity.MedicoId
        };

        return _consultaRepository.EditarDados(consulta);
    }

    public ConsultaEntity? ObterConsultaPorId(int id)
    {
        return _consultaRepository.ObterPorId(id);
    }

    public IEnumerable<ConsultaEntity>? ObterTodasConsultas()
    {
        return _consultaRepository.ObterTodos();
    }

    public ConsultaEntity? SalvarDadosConsulta(ConsultaDto entity)
    {
        var consulta = new ConsultaEntity
        {
            DataConsulta = entity.DataConsulta,
            MotivoConsulta = entity.MotivoConsulta,
            Status = entity.Status,
            BeneficiarioId = entity.BeneficiarioId,
            MedicoId = entity.MedicoId
        };

        return _consultaRepository.SalvarDados(consulta);
    }
}

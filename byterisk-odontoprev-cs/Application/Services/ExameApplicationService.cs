using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;

namespace byterisk_odontoprev_cs.Application.Services;

public class ExameApplicationService : IExameApplicationService
{
    private readonly IExameRepository _exameRepository;

    public ExameApplicationService(IExameRepository exameRepository)
    {
        _exameRepository = exameRepository;
    }

    public ExameEntity? DeletarDadosExame(int id)
    {
        return _exameRepository.DeletarDados(id);
    }

    public ExameEntity? EditarDadosExame(int id, ExameDto entity)
    {
        var exame = new ExameEntity
        {
            Id = id,
            DataExame = entity.DataExame,
            TipoExame = entity.TipoExame,
            ResultadoExame = entity.ResultadoExame,
            BeneficiarioId = entity.BeneficiarioId,
            MedicoId = entity.MedicoId
        };

        return _exameRepository.EditarDados(exame);
    }

    public ExameEntity? ObterExamePorId(int id)
    {
        return _exameRepository.ObterPorId(id);
    }

    public IEnumerable<ExameEntity>? ObterTodosExames()
    {
        return _exameRepository.ObterTodos();
    }

    public ExameEntity? SalvarDadosExame(ExameDto entity)
    {
        var exame = new ExameEntity
        {
            DataExame = entity.DataExame,
            TipoExame = entity.TipoExame,
            ResultadoExame = entity.ResultadoExame,
            BeneficiarioId = entity.BeneficiarioId,
            MedicoId = entity.MedicoId
        };

        return _exameRepository.SalvarDados(exame);
    }
}

using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;

namespace byterisk_odontoprev_cs.Application.Services;

public class PlanoApplicationService : IPlanoApplicationService 
{
    private readonly IPlanoRepository _planoRepository;

    public PlanoApplicationService(IPlanoRepository planoRepository)
    {
        _planoRepository = planoRepository;
    }

    public PlanoEntity? DeletarDadosPlano(int id)
    {
        return _planoRepository.DeletarDados(id);
    }

    public PlanoEntity? EditarDadosPlano(int id, PlanoDto entity)
    {
        var plano = new PlanoEntity
        {
            Id = id,
            NomePlano = entity.NomePlano,
            TipoPlano = entity.TipoPlano,
            ValorMensal = entity.ValorMensal
        };

        return _planoRepository.EditarDados(plano);
    }

    public PlanoEntity? ObterPlanoPorId(int id)
    {
        return _planoRepository.ObterPorId(id);
    }

    public IEnumerable<PlanoEntity>? ObterTodosPlanos()
    {
        return _planoRepository.ObterTodos();
    }

    public PlanoEntity? SalvarDadosPlano(PlanoDto entity)
    {
        var plano = new PlanoEntity
        {
            NomePlano = entity.NomePlano,
            TipoPlano = entity.TipoPlano,
            ValorMensal = entity.ValorMensal
        };

        return _planoRepository.SalvarDados(plano);
    }
}

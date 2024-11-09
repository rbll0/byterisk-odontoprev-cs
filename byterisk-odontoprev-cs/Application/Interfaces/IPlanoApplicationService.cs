using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Application.Interfaces;

public interface IPlanoApplicationService
{
    IEnumerable<PlanoEntity>? ObterTodosPlanos();
    PlanoEntity? ObterPlanoPorId(int id);
    PlanoEntity? SalvarDadosPlano(PlanoDto entity);
    PlanoEntity? EditarDadosPlano(int id, PlanoDto entity);
    PlanoEntity? DeletarDadosPlano(int id);
}

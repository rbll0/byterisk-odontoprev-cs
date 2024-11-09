using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Application.Interfaces;

public interface IExameApplicationService
{
    IEnumerable<ExameEntity>? ObterTodosExames();
    ExameEntity? ObterExamePorId(int id);
    ExameEntity? SalvarDadosExame(ExameDto entity);
    ExameEntity? EditarDadosExame(int id, ExameDto entity);
    ExameEntity? DeletarDadosExame(int id);
}

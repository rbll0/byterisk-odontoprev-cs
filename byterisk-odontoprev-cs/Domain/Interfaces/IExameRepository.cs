using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Domain.Interfaces;

public interface IExameRepository
{
    IEnumerable<ExameEntity>? ObterTodos();
    ExameEntity? ObterPorId(int id);
    ExameEntity? SalvarDados(ExameEntity entity);
    ExameEntity? EditarDados(ExameEntity entity);
    ExameEntity? DeletarDados(int id);
}

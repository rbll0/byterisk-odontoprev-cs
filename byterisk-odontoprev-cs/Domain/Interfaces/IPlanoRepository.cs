using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Domain.Interfaces;

public interface IPlanoRepository
{
    IEnumerable<PlanoEntity>? ObterTodos();
    PlanoEntity? ObterPorId(int id);
    PlanoEntity? SalvarDados(PlanoEntity entity);
    PlanoEntity? EditarDados(PlanoEntity entity);
    PlanoEntity? DeletarDados(int id);
}

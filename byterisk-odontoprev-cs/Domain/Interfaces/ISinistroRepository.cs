using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Domain.Interfaces;

public interface ISinistroRepository
{
    IEnumerable<SinistroEntity>? ObterTodos();
    SinistroEntity? ObterPorId(int id);
    SinistroEntity? SalvarDados(SinistroEntity entity);
    SinistroEntity? EditarDados(SinistroEntity entity);
    SinistroEntity? DeletarDados(int id);
}

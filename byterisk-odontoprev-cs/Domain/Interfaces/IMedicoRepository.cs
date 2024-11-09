using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Domain.Interfaces;

public interface IMedicoRepository
{
    IEnumerable<MedicoEntity>? ObterTodos();
    MedicoEntity? ObterPorId(int id);
    MedicoEntity? SalvarDados(MedicoEntity entity);
    MedicoEntity? EditarDados(MedicoEntity entity);
    MedicoEntity? DeletarDados(int id);
}

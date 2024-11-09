using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Domain.Interfaces;

public interface IBeneficiarioRepository
{
    IEnumerable<BeneficiarioEntity>? ObterTodos();
    BeneficiarioEntity? ObterPorId(int id);
    BeneficiarioEntity? SalvarDados(BeneficiarioEntity entity);
    BeneficiarioEntity? EditarDados(BeneficiarioEntity entity);
    BeneficiarioEntity? DeletarDados(int id);
}

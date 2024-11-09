using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Domain.Interfaces;

public interface IConsultaRepository
{
    IEnumerable<ConsultaEntity>? ObterTodos();
    ConsultaEntity? ObterPorId(int id);
    ConsultaEntity? SalvarDados(ConsultaEntity entity);
    ConsultaEntity? EditarDados(ConsultaEntity entity);
    ConsultaEntity? DeletarDados(int id);
}

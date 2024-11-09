using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Application.Interfaces;

public interface IMedicoApplicationService
{
    IEnumerable<MedicoEntity>? ObterTodosMedicos();
    MedicoEntity? ObterMedicoPorId(int id);
    MedicoEntity? SalvarDadosMedico(MedicoDto entity);
    MedicoEntity? EditarDadosMedico(int id, MedicoDto entity);
    MedicoEntity? DeletarDadosMedico(int id);
}

using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Application.Interfaces;

public interface IBeneficiarioApplicationService
{
    IEnumerable<BeneficiarioEntity>? ObterTodosBeneficiarios();
    BeneficiarioEntity? ObterBeneficiarioPorId(int id);
    BeneficiarioEntity? SalvarDadosBeneficiario(BeneficiarioDto entity);
    BeneficiarioEntity? EditarDadosBeneficiario(int id, BeneficiarioDto entity);
    BeneficiarioEntity? DeletarDadosBeneficiario(int id);
}

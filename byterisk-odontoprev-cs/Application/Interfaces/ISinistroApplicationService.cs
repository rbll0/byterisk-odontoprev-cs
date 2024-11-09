using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Application.Interfaces;

public interface ISinistroApplicationService
{
    IEnumerable<SinistroEntity>? ObterTodosSinistros();
    SinistroEntity? ObterSinistroPorId(int id);
    SinistroEntity? SalvarDadosSinistro(SinistroDto entity);
    SinistroEntity? EditarDadosSinistro(int id, SinistroDto entity);
    SinistroEntity? DeletarDadosSinistro(int id);
}

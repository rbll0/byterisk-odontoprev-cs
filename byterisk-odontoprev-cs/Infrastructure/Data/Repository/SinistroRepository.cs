using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;
using byterisk_odontoprev_cs.Infrastructure.Data.AppData;

namespace byterisk_odontoprev_cs.Infrastructure.Data.Repository;

public class SinistroRepository : ISinistroRepository
{
    private readonly ApplicationContext _context;

        public SinistroRepository(ApplicationContext context)
        {
            _context = context;
        }

        public SinistroEntity? DeletarDados(int id)
        {
            try
            {
                var sinistro = _context.Sinistros.Find(id);

                if (sinistro is not null)
                {
                    _context.Sinistros.Remove(sinistro);
                    _context.SaveChanges();
                    return sinistro;
                }

                throw new Exception("Não foi possível localizar o sinistro");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public SinistroEntity? EditarDados(SinistroEntity entity)
        {
            try
            {
                var sinistro = _context.Sinistros.Find(entity.Id);

                if (sinistro is not null)
                {
                    sinistro.DataSinistro = entity.DataSinistro;
                    sinistro.TipoSinistro = entity.TipoSinistro;
                    sinistro.ValorSinistro = entity.ValorSinistro;
                    sinistro.BeneficiarioId = entity.BeneficiarioId;

                    _context.Update(sinistro);
                    _context.SaveChanges();

                    return sinistro;
                }

                throw new Exception("Não foi possível localizar o sinistro");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public SinistroEntity? ObterPorId(int id)
        {
            return _context.Sinistros.Find(id);
        }

        public IEnumerable<SinistroEntity>? ObterTodos()
        {
            var sinistros = _context.Sinistros.ToList();

            if (sinistros.Any())
                return sinistros;

            return null;
        }

        public SinistroEntity? SalvarDados(SinistroEntity entity)
        {
            try
            {
                _context.Sinistros.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o sinistro");
            }
        }
}

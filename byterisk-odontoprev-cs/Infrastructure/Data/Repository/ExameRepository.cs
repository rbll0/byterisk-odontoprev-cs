using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;
using byterisk_odontoprev_cs.Infrastructure.Data.AppData;

namespace byterisk_odontoprev_cs.Infrastructure.Data.Repository;

public class ExameRepository: IExameRepository
{
    private readonly ApplicationContext _context;

        public ExameRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ExameEntity? DeletarDados(int id)
        {
            try
            {
                var exame = _context.Exames.Find(id);

                if (exame is not null)
                {
                    _context.Exames.Remove(exame);
                    _context.SaveChanges();
                    return exame;
                }

                throw new Exception("Não foi possível localizar o exame");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ExameEntity? EditarDados(ExameEntity entity)
        {
            try
            {
                var exame = _context.Exames.Find(entity.Id);

                if (exame is not null)
                {
                    exame.DataExame = entity.DataExame;
                    exame.TipoExame = entity.TipoExame;
                    exame.ResultadoExame = entity.ResultadoExame;
                    exame.BeneficiarioId = entity.BeneficiarioId;
                    exame.MedicoId = entity.MedicoId;

                    _context.Update(exame);
                    _context.SaveChanges();

                    return exame;
                }

                throw new Exception("Não foi possível localizar o exame");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ExameEntity? ObterPorId(int id)
        {
            return _context.Exames.Find(id);
        }

        public IEnumerable<ExameEntity>? ObterTodos()
        {
            var exames = _context.Exames.ToList();

            if (exames.Any())
                return exames;

            return null;
        }

        public ExameEntity? SalvarDados(ExameEntity entity)
        {
            try
            {
                _context.Exames.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o exame");
            }
        }
}
